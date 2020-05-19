using System.Collections.Generic;

namespace Library.Web.Models.Member
{
    public class MemberIndexModel
    {
        public string ImageUrl { get; set; }
        public IEnumerable<MemberDetailModel> Members { get; set; }
        
    }
}
