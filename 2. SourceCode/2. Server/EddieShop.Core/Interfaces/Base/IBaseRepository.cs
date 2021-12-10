using EddieShop.Core.Entities.Common;
using System;
using System.Collections.Generic;

namespace EddieShop.Core.Interfaces.Base
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>  
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        IEnumerable<TEntity> GetAllEntities(Guid? sessionID);

        /// <summary>
        /// Lấy thông tin theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        TEntity GetEntityById(Guid entityId, Guid? sessionID);



        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin được thêm</param>
        /// <returns>số bản ghi được thêm</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        int Insert(TEntity entity);

        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity">Thông tin cần sửa</param>
        /// <param name="entityId">Id </param>
        /// <param name="sessionID"></param>
        /// <returns>số bản ghi được sửa</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        int Update(TEntity entity, Guid entityId, Guid? sessionID);

        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <param name="entityId">Id </param>
        /// <param name="sessionID"></param>
        /// <returns>Số bản ghi được xóa</returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        int Delete(Guid entityId, Guid? sessionID);

        /// <summary>
        /// Lấy thông tin theo property
        /// </summary>
        /// <param name="columnsGet">Tên property</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        TEntity GetEntityByProperties(object columnsGet, Guid? sessionID);

        /// <summary>
        /// Lấy thông tin theo property
        /// </summary>
        /// <param name="columnsGet">Tên property</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        List<TEntity> GetByValueColumns(TEntity columnsGet, Guid? sessionID);

        /// <summary>
        /// Lấy theo các id 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (24/11/2021)
        List<TEntity> GetByIds(List<Guid> ids, Guid? sessionID);

        /// <summary>
        /// Xóa nhiều 
        /// </summary>
        /// <param name="entityIds"> mảng chứa các Id</param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/8/2021)
        /// ModifiedBy: NTDUNG(27/8/2021)
        int DeleteMultiple(List<Guid> entityIds, Guid? sessionID);

        /// <summary>
        /// Kiểm tra trùng lặp
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fieldName"></param>
        /// <param name="mode"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(04/10/2021)
        Boolean CheckDuplicate(TEntity entity, string fieldName, string mode, Guid? sessionID);

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(07/10/2021)
        string GetNewCode(Guid? sessionID);

        /// <summary>
        /// Lọc và phân trang 
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="filterData"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG(27/10/2021)
        /// ModifiedBy: NTDUNG (10/12/2021)
        Object GetFilterPaging(string filterString, int pageNumber, int pageSize, FilterData filterData, Guid? sessionID);

        /// <summary>
        /// Cập nhật theo tên cột
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <param name="columns"></param>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        /// CreatedBy: NTDUNG (14/11/2021)
        int UpdateColumns(TEntity entity, Guid entityId, List<string> columns, Guid? sessionID);
    }
}
