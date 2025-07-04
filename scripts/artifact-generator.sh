#!/usr/bin/env bash


check_no_changes_in_repository() {
  if ! git diff --quiet; then
    echo "There are uncommitted changes in the repository. Please commit or stash them before running this script."
    read -p "Press enter to continue"
    exit 1
  fi
}

build_java_project_and_sharpen_it(){
  cd java/eu-trusted-lists-resources || exit 1
  echo "Building Java project and sharpening it..."
  mvn clean install -Pwith-sharpen
  if [ $? -ne 0 ]; then
    echo "Failed to build the Java project."
    exit 1
  fi
  echo "Java project built successfully."
  cd ../..
}

create_or_clean_build_folder() {
  if [ -d "build" ]; then
    echo "Cleaning existing build folder..."
    rm -rf build/*
  else
    echo "Creating build folder..."
    mkdir build
  fi
}

package_java_jar_for_maven(){
  echo "Packaging Java JAR for Maven..."
  cd java/eu-trusted-lists-resources || exit 1
  mvn clean install package
  if [ $? -ne 0 ]; then
    echo "Failed to package the Java JAR."
    exit 1
  fi
  echo "Java JAR packaged successfully."
  cd ../..
  cp java/eu-trusted-lists-resources/target/eu-trusted-lists-resources-*.jar build/
  rm build/*sharpen-configuration*
  echo "Java JAR copied to build folder."
}


package_dotnet(){
  echo "Packaging .NET project..."
  cd sharp/eu-trusted-lists-resources/itext/itext.eu-trusted-lists-resources || exit 1
  dotnet pack -c  Release -o ../../../../build
  if [ $? -ne 0 ]; then
    echo "Failed to package the .NET project."
    exit 1
  fi
  echo ".NET project packaged successfully."
  cd ../../../../
}

check_no_changes_in_repository
build_java_project_and_sharpen_it
echo "Java project built and sharpened successfully."
check_no_changes_in_repository

create_or_clean_build_folder
package_java_jar_for_maven
package_dotnet




read -p "Press enter to continue"