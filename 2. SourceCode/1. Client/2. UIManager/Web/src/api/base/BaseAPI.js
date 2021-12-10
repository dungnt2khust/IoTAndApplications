import BaseAPIConfig from './BaseAPIConfig.js'

export default class BaseAPI {
	constructor() {
	}

	controller = "";

	/**
	 * Lấy ra sessionID
	 * @returns {String}
	 */
	getSession() {
		var sessionID = localStorage.getItem('Session');
		var sessionRoute = sessionID ? `sessionID=${sessionID}` : '';
		return sessionRoute;
	}

	/**
	 * Lấy tất cả thông tin
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	getAll(route) {	
		route = route ? route : '';
		return BaseAPIConfig.get(this.controller + route + `?${this.getSession()}`);
	}

	/**
	 * Lấy theo id
	 * @param {string} id
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	getById(id) {
		return BaseAPIConfig.get(this.controller + "/" + id + `?${this.getSession()}`);
	}

	/**
	 * thêm mới
	 * @param {object} body thông tin cần thêm
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	async post(body) {
		return await BaseAPIConfig.post(this.controller + `?${this.getSession()}`, body);
	}

	/**
	 * Chỉnh sửa theo Id
	 * @param {string} id
	 * @param {object} body thông tin chỉnh sửa
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	async put(id, body) {
		return await BaseAPIConfig.put(this.controller + "/" + id + `?${this.getSession()}` , body);
	}

	/**
	 * Xóa nhiều theo Id
	 * @param {Array} listData mảng chứa các id
	 * @returns promise get từ call axios api
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	async deleteMany(body) {
		return await BaseAPIConfig.delete(this.controller + `?${this.getSession()}`, { data: body });
	}
	/**
	 * Xóa theo id
	 * @param {string} id  id của đối tượng
	 * @returns promise
	 * CreatedBy: NTDUNG (01/09/2021)
	 */
	delete(id) {
		return BaseAPIConfig.delete(this.controller + "/" + id + `?${this.getSession()}`);
	}

	/**
	 * Lấy mã mới
	 * @returns {Promise}
	 * CreatedBy: NTDUNG (07/10/2021)
	 */
	getNewCode() {
		return BaseAPIConfig.get(this.controller + "/NewCode" + `?${this.getSession()}`);
	}

    /**
     * Lọc và phân trang
     * @param {String} filterString 
     * @param {Number} pageNumber 
     * @param {Number} pageSize 
     * @param {Object} filterData
     * @returns {Promise}
     * CreatedBy: NTDUNG(29/10/2021)
	 * ModifiedBy: NTDUNG (10/12/2021)
     */
    getFilterPaging(filterString, pageNumber, pageSize, filterData = {}) {
        let api = this.controller + `/Paging?filterString=${filterString}&pageNumber=${pageNumber}&pageSize=${pageSize}` + `&&${this.getSession()}`;
        return BaseAPIConfig.post(api, filterData);
    }

	/**
	 * Cập nhật thông tin theo cột
	 * CreatedBy: NTDUNG (08/12/2021)
	 */
	updateColumns(id, newInfo) {
		var columns = [];
		for (var i in newInfo) {
			columns.push(i);
		}
		return BaseAPIConfig.put(`${this.controller}/UpdateColumns/${id}` + `?${this.getSession()}`, {
			Entity: newInfo,
			Columns: columns
		});
	}
}
