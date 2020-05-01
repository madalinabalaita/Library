using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class ProgramHours
    {
        public int Id { get; set; }
        public LibraryBranch Branch { get; set; }


        //we constraint the value for the day of the week to be between 0-Monday and 6-Sunday
        [Range(0,6)]
        public int Day { get; set; }


        //we constraint the value for the open time to be between 0 and 23 (24h)
        [Range(0,23)]
        public int OpenTime { get; set; }


        //we constraint the value for the closed time to be between 0 and 23 (24h)
        [Range(0,23)]
        public int CloseTime { get; set; }
    }
}
