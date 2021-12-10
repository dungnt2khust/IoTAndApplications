export default {
    methods: {
        _getLocalStorage(key) {
            return JSON.parse(localStorage.getItem(key));
        },
        _setLocalStorage(key, value) {
            localStorage.setItem(key, JSON.stringify(value));
        },
        _getLocalStorageNotParse(key) {
            return localStorage.getItem(key);
        },
        _setLocalStorageNotStringify(key, value) {
            localStorage.setItem(key, value);
        },
        _removeLocalStorage(key) {
            localStorage.removeItem(key);
        },
        _getSessionStorage(key) {
            return JSON.parse(sessionStorage.getItem(key));
        },
        _setSessionStorage(key, value) {
            sessionStorage.setItem(key, JSON.stringify(value));
        }
    } 
}
