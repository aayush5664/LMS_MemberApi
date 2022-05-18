using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;

namespace LibraryReact.Services
{
    public interface IMembersServices
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMemberById(string memberObj);
        Task<Member> UpdateMember(Member memberObj);
        Task<Member> CreateMember(Member memberObj);
        Task<Member> DeleteMember(string memberObj);

    }
}