﻿using System.ComponentModel.DataAnnotations;
using TimeMeasurement_Backend.Entities.Constraints;

namespace TimeMeasurement_Backend.Entities
{
    /// <summary>
    /// Everyone who registeres for a race is stored as a participant
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// only one word
        /// letters
        /// numbers
        /// hyphen,
        /// required
        /// colon
        /// slashes
        /// </summary>
        [Required]
        [RegularExpression(@"^([A-ZÄÜÖ][a-zäüö]+)([- \.\/][A-ZÄÜÖ][a-zäüö]+)*$")]
        public string City { get; set; }

        /// <summary>
        /// Valid email
        /// </summary>
        [Required]
        [IsEmail]
        public string Email { get; set; }

        /// <summary>
        /// Multiple words separated by spaces
        /// Capital initial letter, rest lower case
        /// Within words only letters
        /// At least two letters per name
        /// required
        /// </summary>
        [Required]
        [RegularExpression(@"^([A-ZÄÜÖ][a-zäüö]+)([ ][A-ZÄÜÖ][a-zäüö]+)*$")]
        public string Firstname { get; set; }

        /// <summary>
        /// only letters and numbers
        /// accept umlauts
        /// </summary>
        [Required]
        [RegularExpression(@"^([A-ZÄÜÖa-zäüö0-9\/])+$")]
        public string HouseNumber { get; set; }

        /// <summary>
        /// generated by EntityFramework
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Needs to be a single word or more words seperated with a '-'
        /// Capital initial letter, rest lower case
        /// minimum 2 letters
        /// required
        /// </summary>
        [Required]
        [RegularExpression(@"^[A-ZÄÜÖ][a-zäüö]+(-[A-ZÄÜÖ][a-zäüö]+)?$")]
        public string Lastname { get; set; }

        /// <summary>
        /// ISO - Country
        /// Alpha 3 Code
        /// </summary>
        [IsCountry]
        public string Nationality { get; set; }

        /// <summary>
        /// international standard
        /// </summary>
        [RegularExpression(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[- \./0-9]*$")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// only one word
        /// letters
        /// numbers
        /// hyphen,
        /// required
        /// colon
        /// slashes
        /// </summary>
        [Required]
        [RegularExpression(@"^([A-ZÄÜÖa-zäüö0-9-:\/]+)$")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The Race the Participant registered for
        /// </summary>
        public Race Race { get; set; }

        /// <summary>
        /// only m (male) f (female) or o (other)
        /// required
        /// </summary>
        [Required]
        [RegularExpression(@"^[mfo]$")]
        public string Sex { get; set; }

        /// <summary>
        /// The starter number of the participant
        /// </summary>
        public int Starter { get; set; }

        /// <summary>
        /// Letters
        /// "-", ".", "/", " "
        /// </summary>
        [Required]
        [RegularExpression(@"^([A-ZÄÜÖ][a-zäüö]+)([- \.\/][A-ZÄÜÖ][a-zäüö]+)*$")]
        public string Street { get; set; }

        /// <summary>
        /// The team could be anything
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// The time it took him to complete the race (in ms)
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// first year group: 1920
        /// </summary>
        [Required]
        [Range(1919, 3000)]
        public int YearGroup { get; set; }
    }
}