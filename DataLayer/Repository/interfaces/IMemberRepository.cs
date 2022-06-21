
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> getAllMembers();

        //Role getMemberRole(int roleId);

        Member getMember(string nationalCode);

        Member getMember(int id);

        int memberRegister(Member member);

        int memberUpdate(Member member);

        int deleteMember(int id);
    }
}
