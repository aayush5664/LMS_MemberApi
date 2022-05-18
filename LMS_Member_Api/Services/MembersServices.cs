using LibraryReact.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryReact.Services
{
    public class MembersServices : IMembersServices
    {
        public static readonly List<Member> members = new List<Member>()
        {
            new Member {MemberID="M101",MemberFullName="Akash",MemberDOB="08/01/2000",MemberContactNo="8862003531",MemberEmail="ak@gmail.com",MemberFullAddress="Dwarka,Nashik",MemberPassword="123" },
            new Member { MemberID = "M102", MemberFullName = "Aayush",MemberDOB="29/11/1999",MemberContactNo="8177926762",MemberEmail="as@gmail.com",MemberFullAddress="satpur,Nashik",MemberPassword="123"},
        };

        public async Task<IEnumerable<Member>> GetMembers()
        {
            return members;
        }

        public async Task<Member> GetMemberById(string memberObj)
        {
            return members.SingleOrDefault(c => c.MemberID == memberObj);
        }


        public async Task<Member> CreateMember(Member memberObj)
        {
            members.Add(memberObj);
            return memberObj;
        }

        public async Task<Member> UpdateMember(Member memberObj)
        {
            var result = members.Find(c => c.MemberID == memberObj.MemberID);

            if (result != null)
            {
                result.MemberFullName = memberObj.MemberFullName;
                result.MemberDOB = memberObj.MemberDOB;
                result.MemberContactNo = memberObj.MemberContactNo;
                result.MemberEmail = memberObj.MemberEmail;
                result.MemberFullAddress = memberObj.MemberFullAddress;
                result.MemberPassword = memberObj.MemberPassword;
                

                return result;
            }

            return null;

        }

        public async Task<Member> DeleteMember(string memberObj)
        {
            var result = members.Find(c => c.MemberID == memberObj);
            if (result != null)
            {
                members.Remove(result);

            }
            return result;
        }
    }
}
