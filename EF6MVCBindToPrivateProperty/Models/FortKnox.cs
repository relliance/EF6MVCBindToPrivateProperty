using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;

namespace MyDemo.Models
{
    public partial class FortKnox
    {

        private string Encrypt(string plainText)
        {
            // Not the hardest encryption to crack... not even really encryption
            StringBuilder stb = new StringBuilder();
            if(plainText!=null)
            {
                foreach (var c in plainText.Reverse())
                {
                    stb.Append(c);
                }
            }
            return stb.ToString();
        }

        public string Decrypt(string cipherText)
        {
            // due to the weak encryption, decryption is just the same process again
            return Encrypt(cipherText);
        }

        private string _topSecret;

        /// <summary>
        /// This will hold our secret, it's encrypted when set and decrypted in the get
        /// </summary>
        [NotMapped]
        public string TopSecret
        {
            get
            {
                return Decrypt(_topSecret);
            }
            set
            {
                _topSecret = Encrypt(value);
            }
        }

        /// <summary>
        /// This allows Entity Framework to store/work with our private field <see cref="ValueForDB"/>
        /// </summary>
        public class FortKnoxConfig : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FortKnox>
        {
            public FortKnoxConfig()
            {
                Property(b => b.ValueForDB);
            }
        }


        /// <summary>
        /// This is the property that Entity Framework will store from and 
        /// retrieve into yet its private so the rest of the system can't 
        /// access it (mainly concerned with preventing code from writing  
        /// to the backing field without applying encryption)
        /// </summary>
        [Column("TopSecret")]
        private string ValueForDB
        {
            get
            {
                return _topSecret;
            }
            set
            {
                _topSecret = value;
            }
        }


        public int ID { get; set; }
        public string OtherDataWeDontCareAbout { get; set; }


    }
}