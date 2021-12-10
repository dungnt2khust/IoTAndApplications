import BaseAPI from '@/api/base/BaseAPI.js';

class AdminAPI extends BaseAPI {
    constructor() {
        super();
        this.controller = 'Admin';
    }
}

export default new AdminAPI();