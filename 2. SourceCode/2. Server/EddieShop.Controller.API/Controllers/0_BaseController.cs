using EddieShop.Core.Entities;
using EddieShop.Core.Entities.Common;
using EddieShop.Core.Interfaces.Base;
using EddieShop.Core.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace EddieShop.Controller.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        #region Declare
        IBaseService<TEntity> _baseService;
        #endregion

        #region Constructor
        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method

        #region GetAll
        /// <summary>
        /// Lấy danh sách
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        [HttpGet]
        public IActionResult GetAllEntities(Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.GetAllEntities(sessionID);
                //4.Trả về kết quả cho client
                if (serviceResult.Data != null)
                {
                    return StatusCode(200, serviceResult);
                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region GetById
        /// <summary>
        /// Lấy thông tin theo Id
        /// </summary>
        /// <param name="entityId">Id</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        [HttpGet("{entityId}")]
        public IActionResult GetEntityById(Guid entityId, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.GetEntityById(entityId, sessionID);
                if (serviceResult.Data != null)
                {
                    return StatusCode(200, serviceResult);
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }

        }
        #endregion

        #region GetByProperties
        /// <summary>
        /// Lấy thông tin theo Id
        /// </summary>
        /// <param name="columnsGet"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(23/11/2021)
        [HttpPost("GetByProperties")]
        public IActionResult GetByProperties(TEntity columnsGet, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.GetByValueColumns(columnsGet, sessionID);
                if (serviceResult.Data != null)
                {
                    return StatusCode(200, serviceResult);
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }

        }
        #endregion

        #region GetByValueColumns
        /// <summary>
        /// Lấy thông tin theo Id
        /// </summary>
        /// <param name="columnsGet"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(23/11/2021)
        [HttpPost("GetByValueColumns")]
        public IActionResult GetByValueColumns(TEntity columnsGet, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.GetByValueColumns(columnsGet, sessionID);
                if (serviceResult.Data != null)
                {
                    return StatusCode(200, serviceResult);
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region GetByIds
        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (24/11/2021)
        [HttpPost("GetByIds")]
        public IActionResult GetByIds(List<Guid> ids, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.GetByIds(ids, sessionID);
                if (serviceResult.Data != null)
                {
                    return StatusCode(200, serviceResult);
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region Insert
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Dữ liệu được thêm</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        [HttpPost]
        public IActionResult Insert(TEntity entity, Guid? sessionID)
        {
            try
            {
                //Trả về kết quả cho client
                var serviceResult = _baseService.Insert(entity, sessionID);
                if (serviceResult.Success)
                {
                    return StatusCode(201, serviceResult);
                }
                else
                {
                    return BadRequest(serviceResult);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }

        }
        #endregion

        #region Update
        /// <summary>
        /// Chỉnh sửa theo Id
        /// </summary>
        /// <param name="entityId">Id</param>
        /// <param name="entity">Thông tin muốn thay đổi</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        [HttpPut("{entityId}")]
        public IActionResult Update(Guid entityId, TEntity entity, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.Update(entity, entityId, sessionID);
                if (serviceResult.Success)
                {

                    return Ok(serviceResult);
                }
                else
                {
                    return BadRequest(serviceResult);
                }

            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region DeleteOne
        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="entityId">Id </param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.Delete(entityId, sessionID);
                return Ok(serviceResult);
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = ResourceVN.Exception_ErrorMsg,
                    errorCode = "Eddie-001",
                    moreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region DeleteMany
        /// <summary>
        /// Xóa nhiều
        /// </summary>
        /// <param name="entityIds">chuỗi chứa các Id</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        /// ModifiedBy: NTDUNG(17/8/2021)
        [HttpDelete]
        public IActionResult DeleteMultiple([FromBody] List<Guid> entityIds, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.DeleteMultiple(entityIds, sessionID);
                return Ok(serviceResult);
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = ResourceVN.Exception_ErrorMsg,
                    errorCode = "Eddie-001",
                    moreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region GetNewCode
        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(07/10/2021)
        [HttpGet("NewCode")]
        public IActionResult GetNewCode(Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.GetNewCode(sessionID);
                return Ok(serviceResult);
            }
            catch (Exception ex)
            {
                var errorObj = new
                {
                    devMsg = ex.Message,
                    userMsg = ResourceVN.Exception_ErrorMsg,
                    errorCode = "Eddie-001",
                    moreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region GetFilterPaging
        /// <summary>
        /// Lọc và phân trang
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalFields"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(28/10/2021)
        [HttpPost("Paging")]
        public IActionResult GetFilterPaging(string filterString, int pageNumber, int pageSize, [FromBody] FilterData filterData, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.GetFilterPaging(filterString, pageNumber, pageSize, filterData, sessionID);
                //4.Trả về kết quả cho client
                if (serviceResult.Data != null)
                {
                    return StatusCode(200, serviceResult);
                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }
        }
        #endregion

        #region UpdateColumns
        /// <summary>
        /// Chỉnh sửa theo Id một số cột
        /// </summary>
        /// <param name="entityId">Id</param>
        /// <param name="data">Thông tin muốn thay đổi</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(17/8/2021)
        [HttpPut("UpdateColumns/{entityId}")]
        public IActionResult UpdateColumns(Guid entityId, UpdateColumns<TEntity> updateColumns, Guid? sessionID)
        {
            try
            {
                var serviceResult = _baseService.UpdateColumns(updateColumns.Entity, entityId, updateColumns.Columns, sessionID);
                if (serviceResult.Success)
                {

                    return Ok(serviceResult);
                }
                else
                {
                    return BadRequest(serviceResult);
                }

            }
            catch (Exception ex)
            {
                var errorObj = new ServiceResult();

                errorObj.Success = false;
                errorObj.Msg = ResourceVN.Exception_ErrorMsg;
                errorObj.DevMsg = ex.Message;
                errorObj.Code = "Eddie-001";
                errorObj.MoreInfo = "https://openapi.Eddie.com.vn/errorcode/Eddie-001";
                errorObj.TraceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb";

                return StatusCode(500, errorObj);
            }
        }
        #endregion
        #endregion
    }
}
