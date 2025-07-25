#!/usr/bin/env groovy
import com.itextpdf.GeneralVariables
import com.itextpdf.ColorCodings

pipeline {
    agent { label 'windows' }

    options {
        ansiColor 'xterm'
        parallelsAlwaysFailFast()
        skipStagesAfterUnstable()
        timestamps()
    }

    stages {
        stage('Build Java') {
            when { branch 'master' }
            steps {
                script {
                    println "\n${ColorCodings.GREENBOLD}Build Java${ColorCodings.NC}"
                    configFileProvider([configFile(fileId: GeneralVariables.mavenGlobalSettings, variable: 'MAVEN_SETTINGS')]) {
                        withMaven(jdk: GeneralVariables.jdkVersionSharpenBuild, maven: GeneralVariables.Maven) {
                            def mvnSettings = 
                                "--global-settings ${MAVEN_SETTINGS.replace '\\', '/'} " +
                                "-Dmaven.repo.local=${env.WORKSPACE.replace('\\','/')}/.repository"
                            dir ('java/eu-trusted-lists-resources') {
                                sh 'mvn --no-transfer-progress clean install -Pwith-sharpen ' + mvnSettings
                                sh 'mvn --no-transfer-progress clean package ' + mvnSettings
                            }
                        }
                    }
                }
            }
        }
        stage('Build .NET') {
            when { branch 'master' }
            steps {
                script {
                    println "\n${ColorCodings.GREENBOLD}Build .NET${ColorCodings.NC}"
                    dir ('sharp/eu-trusted-lists-resources/itext/itext.eu-trusted-lists-resources') {
                        bat 'dotnet pack -c Release'
                        dir ('bin/Release') {
                            archiveArtifacts artifacts: '*.nupkg',
                                fingerprint: true,
                                onlyIfSuccessful: true
                        }
                    }
                }
            }
        }
        stage('Upload to Artifactory Java') {
            when { branch 'master' }
            steps {
                script {            
                    println "\n${ColorCodings.GREENBOLD}Upload to Artifactory Java${ColorCodings.NC}"
                    configFileProvider([configFile(fileId: GeneralVariables.mavenGlobalSettings, variable: 'MAVEN_SETTINGS')]) {
                        withMaven(
                            options: [junitPublisher(disabled: true), artifactsPublisher(disabled: true)],
                            jdk: GeneralVariables.JDK_VERSION,
                            maven: GeneralVariables.Maven,
                            mavenSettingsConfig: GeneralVariables.mavenGlobalSettings
                        ) {
                            dir ('java/eu-trusted-lists-resources') {
                                def server = Artifactory.server 'itext-artifactory'
                                def rtMaven = Artifactory.newMavenBuild()
                                rtMaven.tool = GeneralVariables.Maven
                                def mvnGoals = "--no-transfer-progress install -Dmaven.main.skip=true -Dmaven.test.skip=true --global-settings ${MAVEN_SETTINGS.replace '\\', '/'} -Dmaven.repo.local=${env.WORKSPACE.replace '\\', '/'}/.repository"
                                rtMaven.deployer server: server, releaseRepo: 'releases-internal', snapshotRepo: 'snapshot-internal'
                                rtMaven.deployer.artifactDeploymentPatterns.addExclude '*sharpen-config*'
                                def buildInfo = rtMaven.run pom: 'pom.xml', goals: mvnGoals.toString()
                                server.publishBuildInfo buildInfo
                            }
                        }
                    }
                }
            }
        }
        stage('Upload to Artifactory .NET') {
            when { branch 'master' }
            steps {
                script {
                    println "\n${ColorCodings.GREENBOLD}Upload to Artifactory .NET${ColorCodings.NC}"
                    def buildInfo = Artifactory.newBuildInfo()
                    def uploadSpec = """{"files": [""" +
                        findFiles(glob: 'sharp/eu-trusted-lists-resources/itext/itext.eu-trusted-lists-resources/bin/Release/**/*.nupkg').collect{"""{"pattern": "${it.path}", "target": "nuget-internal/itext.eu-trusted-lists-resources/", "flat": "true", "recursive": "false"}"""}.join(", ") +
                        """]}"""
                    def server = Artifactory.server 'itext-artifactory'
                    server.upload(uploadSpec, buildInfo)
                }
            }
        }
    }
    post {
        success {
            println "\n${ColorCodings.GREENBOLD}Cleanup${ColorCodings.NC}"
            cleanWs()
        }
    }
}