using System;
using System.Collections.Generic;

namespace iText.Eutrustedlistsresources {
    /// <summary>Configuration class for the European Union Trusted List.</summary>
    /// <remarks>
    /// Configuration class for the European Union Trusted List.
    /// It provides the URI to the trusted list and a list of certificates.
    /// </remarks>
    public class EuropeanTrustedListConfiguration {
        private const String euTrustedListUrl = "https://ec.europa.eu/tools/lotl/eu-lotl.xml";

        private readonly Uri euTrustedListUri;

        /// <summary>
        /// Initializes a new instance of the
        /// <c>EuTrustedListConfig</c>
        /// class.
        /// </summary>
        public EuropeanTrustedListConfiguration() {
            try {
                euTrustedListUri = new Uri(euTrustedListUrl);
            }
            catch (UriFormatException e) {
                throw new Exception(e.Message);
            }
        }

        /// <summary>Returns the URI of the European Union Trusted List.</summary>
        /// <returns>the URI of the trusted list</returns>
        public virtual Uri GetTrustedListUri() {
            return euTrustedListUri;
        }

        /// <summary>Returns a list of certificates.</summary>
        /// <returns>a list of certificate strings</returns>
        public virtual IList<EuropeanTrustedListConfiguration.PemCertificateWithHash> GetCertificates() {
            return Util.ArraysAsList(new EuropeanTrustedListConfiguration.PemCertificateWithHash(Certificates2019C27601
                .certificate1, Certificates2019C27601.certificate1SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.certificate2, Certificates2019C27601.certificate2SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.certificate3, Certificates2019C27601.certificate3SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.certificate4, Certificates2019C27601.certificate4SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.certificate5, Certificates2019C27601.certificate5SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.certificate6, Certificates2019C27601.certificate6SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.certificate7, Certificates2019C27601.certificate7SHA256), new EuropeanTrustedListConfiguration.PemCertificateWithHash
                (Certificates2019C27601.certificate8, Certificates2019C27601.certificate8SHA256));
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
