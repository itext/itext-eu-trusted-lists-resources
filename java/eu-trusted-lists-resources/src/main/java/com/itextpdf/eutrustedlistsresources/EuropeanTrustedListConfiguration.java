package com.itextpdf.eutrustedlistsresources;

import java.net.URI;
import java.net.URISyntaxException;
import java.util.Arrays;
import java.util.List;

/**
 * Configuration class for the European Union Trusted List.
 * It provides the URI to the trusted list and a list of certificates.
 */
public class EuropeanTrustedListConfiguration {

    private static final String euTrustedListUrl = "https://ec.europa.eu/tools/lotl/eu-lotl.xml";

    private final URI euTrustedListUri;

    /**
     * Initializes a new instance of the {@code EuTrustedListConfig} class.
     */
    public EuropeanTrustedListConfiguration() {
        try {
            euTrustedListUri = new URI(euTrustedListUrl);
        } catch (URISyntaxException e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Returns the URI of the European Union Trusted List.
     *
     * @return the URI of the trusted list
     */
    public URI getTrustedListUri() {
        return euTrustedListUri;
    }


    /**
     * Returns a list of certificates.
     *
     * @return a list of certificate strings
     */
    public List<PemCertificateWithHash> getCertificates() {
        return Arrays.asList(
                new PemCertificateWithHash(Certificates2019C27601.certificate1,
                        Certificates2019C27601.certificate1SHA256),
                new PemCertificateWithHash(Certificates2019C27601.certificate2,
                        Certificates2019C27601.certificate2SHA256),
                new PemCertificateWithHash(Certificates2019C27601.certificate3,
                        Certificates2019C27601.certificate3SHA256),
                new PemCertificateWithHash(Certificates2019C27601.certificate4,
                        Certificates2019C27601.certificate4SHA256),
                new PemCertificateWithHash(Certificates2019C27601.certificate5,
                        Certificates2019C27601.certificate5SHA256),
                new PemCertificateWithHash(Certificates2019C27601.certificate6,
                        Certificates2019C27601.certificate6SHA256),
                new PemCertificateWithHash(Certificates2019C27601.certificate7,
                        Certificates2019C27601.certificate7SHA256),
                new PemCertificateWithHash(Certificates2019C27601.certificate8,
                        Certificates2019C27601.certificate8SHA256)
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
