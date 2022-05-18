using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryReact.Services;
using LibraryReact.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace LibraryReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersServices _memberServices;

        public MembersController(IMembersServices memberServices)
        {
            _memberServices = memberServices;
        }

        [HttpGet("GetMembers/")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            try
            {
                return (await _memberServices.GetMembers()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetMemberById/{id}")]
        public async Task<ActionResult<Member>> GetMemberById(string id)
        {

            try
            {
                var result = await _memberServices.GetMemberById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("CreateMember/")]
        public async Task<ActionResult<Member>> CreateMember(Member memberObj)
        {
            string message = "faild";
            try
            {
                if (memberObj == null)
                    return BadRequest();

                var createmember = await _memberServices.CreateMember(memberObj);
                if (createmember != null)
                {
                    message = "success";
                }
                else
                {
                    message = "faild";
                }
            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpPut("UpdateMember/")]
        public async Task<ActionResult<Member>> UpdateMember(Member memberObj)
        {
            string message = "";
            try
            {
                if (memberObj.MemberID != memberObj.MemberID)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await _memberServices.UpdateMember(memberObj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _memberServices.UpdateMember(memberObj);
                    message = "success";
                }



            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("DeleteMember/{id}")]
        public async Task<ActionResult<Member>> DeleteMember(string id)
        {
            string message = "";
            try
            {
                var memberdelete = await _memberServices.GetMemberById(id);

                if (memberdelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _memberServices.DeleteMember(id);
                    message = "success";
                }

            }
            catch (Exception)
            {
                message = "unable to delete";
                return Ok(message);
            }
            return Ok(message);
        }

    }
}
