using EH.DAL.Interface;
using EH.ViewModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EH.ResourceServerAPI.Controllers
{
    /// <summary>
    /// Contacts API Controller
    /// </summary>

    [AllowAnonymous]
    public class ContactsController : BaseController
    {
        private readonly IContactService _contactService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contactService">Instance of type contactService</param>
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Gets All Status 
        /// </summary>
        /// <returns>Collection of StatusVM object list.</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetStatusList()
        {
            var results = await _contactService.GetStatusList();
            return Ok(results);
        }

        /// <summary>
        /// Gets All Contacts Available
        /// </summary>
        /// <returns>Collection of ContactVM object list.</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetContactList()
        {
            var results = await _contactService.GetContactList();
            return Ok(results);
        }

        /// <summary>
        /// Gets Customer for a given Customer Id
        /// </summary>
        /// <param name="xiContactId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetContactById(int xiContactId)
        {
            ContactVM result = await _contactService.GetContactById(xiContactId);
            if (result == null)
            {
                return Content(HttpStatusCode.NotFound, "Contact not Found");
            }
            return Ok(result);
        }

        /// <summary>
        /// Creates a new Customer
        /// </summary>
        /// <param name="xiContactVM"><see cref="ContactVM"/></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> InsertContact(ContactVM xiContactVM)
        {
            IHttpActionResult response;
            if (ModelState.IsValid)
            {
                bool status = await _contactService.InsertContact(xiContactVM);
                if (status)
                {
                    return Ok("Record inserted successfully");
                }
                
                return Content(HttpStatusCode.NotFound, "Sorry failed to insert record! Please try again or contact administrator if problem persist.");
            }

            HttpResponseMessage responseMsg = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            response = ResponseMessage(responseMsg);
            return response;  // implemnted Custom Messdage with additional deatils bac.


        }

        /// <summary>
        /// Updates a ContactVM
        /// </summary>
        /// <param name="xiContactVM"><see cref="ContactVM"/></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> UpdateContact(ContactVM xiContactVM)
        {
            if (ModelState.IsValid)
            {
                bool status = await _contactService.UpdateContact(xiContactVM);
                if (status)
                {
                    return Ok("Record updated successfully");
                }

                return Content(HttpStatusCode.NotFound, "Sorry failed to update record! Please try again or contact administrator if problem persist.");
            }

            HttpResponseMessage responseMsg = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            return ResponseMessage(responseMsg); // handle custom error message.
        }

        /// <summary>
        /// Deletes the specified ContactVM
        /// </summary>
        /// <param name="xiContactId">ContactVM Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteContact(int xiContactId)
        {
            bool status = await _contactService.DeleteContact(xiContactId);
            if (status)
            {
                return Ok("Record deleted successfully");
            }

            return Content(HttpStatusCode.NotFound, "Sorry failed to delete record! Please try again or contact administrator if problem persist.");
        }
    }
}
