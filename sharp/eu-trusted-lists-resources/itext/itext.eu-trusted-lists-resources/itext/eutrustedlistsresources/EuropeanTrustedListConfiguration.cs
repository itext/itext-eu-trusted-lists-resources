using System;
using System.Collections.Generic;

namespace iText.Eutrustedlistsresources {
    /// <summary>Configuration class for the European Union Trusted List.</summary>
    /// <remarks>
    /// Configuration class for the European Union Trusted List.
    /// It provides the URI to the trusted list and a list of certificates.
    /// </remarks>
    public class EuropeanTrustedListConfiguration {
        private const String EU_TRUSTED_LISTS_URL = "https://ec.europa.eu/tools/lotl/eu-lotl.xml";

        private const String CURRENTLY_SUPPORTED_PUBLICATION = "https://eur-lex.europa" + ".eu/legal-content/EN/TXT/?uri=uriserv:OJ.C_.2019.276.01.0001.01.ENG";

        /// <summary>Default constructor for the EuropeanTrustedListConfiguration.</summary>
        public EuropeanTrustedListConfiguration() {
        }

        // Default constructor
        /// <summary>Returns the url of the European Union Trusted List.</summary>
        /// <returns>the url of the trusted list</returns>
        public virtual String GetTrustedListUri() {
            return EU_TRUSTED_LISTS_URL;
        }

        /// <summary>Returns the currently supported publication of the European Union Trusted List.</summary>
        /// <returns>the currently supported publication URL.</returns>
        public virtual String GetCurrentlySupportedPublication() {
            return CURRENTLY_SUPPORTED_PUBLICATION;
        }

        /// <summary>Returns a list of certificates.</summary>
        /// <returns>a list of certificate strings</returns>
        public virtual IList<EuropeanTrustedListConfiguration.PemCertificateWithHash> GetCertificates() {
            return Util.ArraysAsList(new EuropeanTrustedListConfiguration.PemCertificateWithHash(Certificates2019C27601
                .CERTIFICATE_1, Certificates2019C27601.CERTIFICATE_1_SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.CERTIFICATE_2, Certificates2019C27601.CERTIFICATE_2_SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.CERTIFICATE_3, Certificates2019C27601.CERTIFICATE_3_SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.CERTIFICATE_4, Certificates2019C27601.CERTIFICATE_4_SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.CERTIFICATE_5, Certificates2019C27601.CERTIFICATE_5_SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.CERTIFICATE_6, Certificates2019C27601.CERTIFICATE_6_SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.CERTIFICATE_7, Certificates2019C27601.CERTIFICATE_7_SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.CERTIFICATE_8, Certificates2019C27601.CERTIFICATE_8_SHA256));
        }

        /// <summary>Represents a PEM certificate along with its SHA-256 base64 encoded hash.</summary>
        public class PemCertificateWithHash {
            private readonly String pemCertificate;

            private readonly String hash;

            /// <summary>
            /// Constructs a new instance of
            /// <c>PemCertificateWithHash</c>.
            /// </summary>
            /// <param name="pemCertificate">the PEM formatted certificate</param>
            /// <param name="hash">the SHA-256 base64 encoded hash of the certificate</param>
            public PemCertificateWithHash(String pemCertificate, String hash) {
                this.pemCertificate = pemCertificate;
                this.hash = hash;
            }

            /// <summary>Returns the PEM formatted certificate.</summary>
            /// <returns>the PEM certificate</returns>
            public virtual String GetPemCertificate() {
                return pemCertificate;
            }

            /// <summary>Returns the SHA-256 hash base64 encoded of the certificate.</summary>
            /// <returns>the hash of the certificate</returns>
            public virtual String GetHash() {
                return hash;
            }
        }
    }
}
