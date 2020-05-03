using Library.Models.MemberModel;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class MemberController:Controller
    {
        public IMember _member;
        public MemberController(IMember member)
        {
            _member = member;
        }
        public IActionResult Index()
        {
            var allMembers = _member.GetAll();
            var memberModels = allMembers.Select(m => new MemberDetailModel
            {
                Id = m.Id,
                FirstName=m.FirstName,
                LastName=m.LastName,
                LibrarySubscriptionId=m.LibrarySubscription.Id,
                OverdueFees=m.LibrarySubscription.Fees,

            }).ToList();
            var model = new MemberIndexModel()
            {
                Members = memberModels
            };
            return View(model);
        }
    }
}
