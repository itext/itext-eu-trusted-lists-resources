package com.itextpdf.eutrustedlistsresources;

import java.util.Arrays;
import java.util.List;

/**
 * Configuration class for the European Union Trusted List.
 * It provides the URI to the trusted list and a list of certificates.
 */
public class EuropeanTrustedListConfiguration {

    private static final String EU_TRUSTED_LISTS_URL = "https://ec.europa.eu/tools/lotl/eu-lotl.xml";
    private static final String CURRENTLY_SUPPORTED_PUBLICATION = "https://eur-lex.europa" +
            ".eu/legal-content/EN/TXT/?uri=uriserv:OJ.C_.2019.276.01.0001.01.ENG";

    /**
     * Default constructor for the EuropeanTrustedListConfiguration.
     */
    public EuropeanTrustedListConfiguration() {
        // Default constructor
    }


    /**
     * Returns the url of the European Union Trusted List.
     *
     * @return the url of the trusted list
     */
    public String getTrustedListUri() {
        return EU_TRUSTED_LISTS_URL;
    }

    /**
     * Returns the currently supported publication of the European Union Trusted List.
     *
     * @return the currently supported publication URL.
     */
    public String getCurrentlySupportedPublication() {
        return CURRENTLY_SUPPORTED_PUBLICATION;
    }

    /**
     * Returns a list of certificates.
     *
     * @return a list of certificate strings
     */
    public List<PemCertificateWithHash> getCertificates() {
        return Arrays.asList(
                new PemCertificateWithHash(Certificates2019C27601.CERTIFICATE_1,
                        Certificates2019C27601.CERTIFICATE_1_SHA256),
                new PemCertificateWithHash(Certificates2019C27601.CERTIFICATE_2,
                        Certificates2019C27601.CERTIFICATE_2_SHA256),
                new PemCertificateWithHash(Certificates2019C27601.CERTIFICATE_3,
                        Certificates2019C27601.CERTIFICATE_3_SHA256),
                new PemCertificateWithHash(Certificates2019C27601.CERTIFICATE_4,
                        Certificates2019C27601.CERTIFICATE_4_SHA256),
                new PemCertificateWithHash(Certificates2019C27601.CERTIFICATE_5,
                        Certificates2019C27601.CERTIFICATE_5_SHA256),
                new PemCertificateWithHash(Certificates2019C27601.CERTIFICATE_6,
                        Certificates2019C27601.CERTIFICATE_6_SHA256),
                new PemCertificateWithHash(Certificates2019C27601.CERTIFICATE_7,
                        Certificates2019C27601.CERTIFICATE_7_SHA256),
                new PemCertificateWithHash(Certificates2019C27601.CERTIFICATE_8,
                        Certificates2019C27601.CERTIFICATE_8_SHA256)
        );
    }

    /**
     * Represents a PEM certificate along with its SHA-256 base64 encoded hash.
     */
    public static class PemCertificateWithHash {
        private final String pemCertificate;
        private final String hash;

        /**
         * Constructs a new instance of {@code PemCertificateWithHash}.
         *
         * @param pemCertificate the PEM formatted certificate
         * @param hash           the SHA-256 base64 encoded hash of the certificate
         */
        public PemCertificateWithHash(String pemCertificate, String hash) {
            this.pemCertificate = pemCertificate;
            this.hash = hash;
        }

        /**
         * Returns the PEM formatted certificate.
         *
         * @return the PEM certificate
         */
        public String getPemCertificate() {
            return pemCertificate;
        }

        /**
         * Returns the SHA-256 hash base64 encoded of the certificate.
         *
         * @return the hash of the certificate
         */
        public String getHash() {
            return hash;
        }
    }

}
