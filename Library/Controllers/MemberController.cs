using Library.Web.Models.Member;
using Library.Data;
using Library.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.Web.Controllers
{
    public class MemberController : Controller
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
                FirstName = m.FirstName,
                LastName = m.LastName,
                LibrarySubscriptionId = m.LibrarySubscription.Id,
                OverdueFees = m.LibrarySubscription.Fees,

            }).ToList();
            var model = new MemberIndexModel()
            {
                Members = memberModels
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var member = _member.Get(id);
            var model = new MemberDetailModel()
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Address = member.Address,
                MemberSince = member.LibrarySubscription.Created.ToString("dd/MM/yyyy"),
                DateOfBirth=member.DateOfBirth.ToString("dd/MM/yyyy"),
                OverdueFees = member.LibrarySubscription.Fees,
                LibrarySubscriptionId = member.LibrarySubscription.Id,
                Phone = member.PhoneNr,
                ItemsBorrowed = _member.GetBorrows(id).ToList() ?? new List<Borrow>(),
                BorrowHistory = _member.GetBorrowHistory(id),
                Holds = _member.GetHolds(id),
                Gender = member.Gender,
                ImageUrl=member.ImageUrl
                
            };
            return View(model);
        }
    }
}