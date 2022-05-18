using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class Member
    {

        [Key]
        public string MemberID { get; set; }
        public string MemberFullName { get; set; }
        public string MemberDOB { get; set; }
        public string MemberContactNo { get; set; }
        public string MemberEmail { get; set; }
        public string MemberFullAddress { get; set; }
        public string MemberPassword { get; set; }

    }
}
