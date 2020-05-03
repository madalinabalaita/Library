using Library.Models.Member;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
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

        public IActionResult Detail(int memberId)
        {
            var member = _member.Get(memberId);
            var model = new MemberDetailModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Address = member.Address,
                MemberSince = member.LibrarySubscription.Created,
                OverdueFees = member.LibrarySubscription.Fees,
                LibrarySubscriptionId = member.LibrarySubscription.Id,
                Phone = member.PhoneNr,
                ItemsBorrowed = _member.GetBorrows(memberId).ToList() ?? new List<Borrow>(),
                BorrowHistory = _member.GetBorrowHistory(memberId),
                Holds = _member.GetHolds(memberId)
            };
            return View(model);
        }
    }
}