using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repository;

namespace DataLayer.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private BookContext _DbContext;

        public MemberRepository(BookContext bookContext)
        {
            _DbContext = bookContext;
        }

       

        public IEnumerable<Member> getAllMembers()
        {
            return _DbContext.Members;
        }

        public Member getMember(string nationalCode)
        {
            return _DbContext.Members.
                    Where(member => member.NationalCode == nationalCode).
                    FirstOrDefault();
        }

        public Member getMember(int id)
        {
            return _DbContext.Members.
                 Where(member => member.MemberId == id).
                 FirstOrDefault();
        }

        public int memberRegister(Member member)
        {
            _DbContext.Members.Add(member);
            return _DbContext.SaveChanges();
        }

        public int memberUpdate(Member member) {
            var result =_DbContext.Members.
                SingleOrDefault(m => m.MemberId == member.MemberId);
            if (result != null) {
                result.Name = member.Name;
                result.Family = member.Family;
                result.NationalCode = member.NationalCode;
                result.MobileNumber = member.MobileNumber;
                result.RegistrationDate = member.RegistrationDate;  
                var retval = _DbContext.SaveChanges();
                return retval;
            }
            return 0;
        }

        public int deleteMember(int id)
        {
            var result = _DbContext.Members.
                SingleOrDefault(m => m.MemberId == id);
            if (result != null)
            {
                _DbContext.Members.Remove(result);
                var retval = _DbContext.SaveChanges();
                return retval;
            }
            return 0;
        }
    }
}

