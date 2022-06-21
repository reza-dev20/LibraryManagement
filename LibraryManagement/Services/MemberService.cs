using DataLayer.Model;
using DataLayer.Repository;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Services
{
    public class MemberService : IMemberService
    {
        private IMemberRepository _MemberRepo;
        public MemberService(IMemberRepository memberRepo)
        {
            _MemberRepo = memberRepo;
        }
       

        public IEnumerable<Member> getAllMembers()
        {
            return _MemberRepo.getAllMembers();
        }

        public Member getMember(string nationalCode)
        {
            return _MemberRepo.getMember(nationalCode);
        }

        public Member getMember(int id)
        {
            return _MemberRepo.getMember(id);
        }

        public int memberRegister(Member member)
        {
            return _MemberRepo.memberRegister(member);
        }

        public int memberUpdate(Member member)
        {
            return _MemberRepo.memberUpdate(member);
        }

        public int deleteMember(int id)
        {
            return _MemberRepo.deleteMember(id);
        }
    }
}