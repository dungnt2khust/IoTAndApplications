export default {
    methods: {
        /**
         * Tuỳ chỉnh style
         * @param {Object} attributes
         * @returns Object
         * CreatedBy: NTDUNG (22/11/2021)
         */
        customizeStyle(attributes) {
           var customizeStyleObject = {};
           for(var att in attributes) {
               if (attributes[att]) { 
                   customizeStyleObject[att] = attributes[att] + "!important";
               }
           }
           return customizeStyleObject;
        },
        /**
         * Trượt xuống element
         * CreatedBy: NTDUNG (25/11/2021)
         */
        scrollElement(element, type = "END") {
            if (element) {
                var childElements = element.children;
                var numChildElements = childElements.length;
                var childScroll;

                switch(type) {
                    case "START":
                        childScroll = childElements[0];
                        break;
                    case "END":
                        childScroll = childElements[numChildElements - 1];
                        break;
                }
                this.$nextTick(() => {
                    if (childScroll)
                        childScroll.scrollIntoView();
                });
            }
        },
        /**
         * Kiểm tra element có thuộc một element cha có class cho trước hay không
         * @param {Element} element
         * @param {String} className
         * CreatedBy: NTDUNG (30/11/2021)
         */
        checkElementNestedByClass(element, className) {
            if (element && className) {
                var parentE = element;
                if (parentE) {
                    // Nếu không chứa class thì tiếp tục vòng lặp
                    while (parentE.classList.contains(className) == false) {
                        // Đi ra một element cha
                        parentE = parentE.parentElement;

                        // Khi đã duyệt hết mà không có thì set null và thoát vòng lặp
                        if (parentE.tagName == "BODY") {
                            parentE = null;
                            break;
                        }
                    }
                }
                // Trả về kết quả
                return parentE;
            } 
            else 
                return null;
        },
        /**
		 * Kiểm tra phải object không
		 * @param {object} object: object cần kiểm tra
		 * CreatedBY: NTDUNG(01/10/2021) - Referenced
		 */
		isObject(object) {
			return object != null && typeof object === "object";
		},
		/**
		 * So sánh sâu 2 object
		 * @param {Object} object1
		 * @param {Object} object2
		 * @param {Array} escapeFields
		 * @returns {Boolean}
		 * CreatedBy: NTDUNG(01/10/2021) - Referenced
		 */
		deepEqualObject(object1, object2, escapeFields = []) {
			const keys1 = Object.keys(object1);
			const keys2 = Object.keys(object2);
			if (keys1.length !== keys2.length) {
				return false;
			}
			for (const key of keys1) {
				const val1 = object1[key];
				const val2 = object2[key];
				const areObjects = this.isObject(val1) && this.isObject(val2);
				if (
					(areObjects && !this.deepEqualObject(val1, val2, escapeFields)) ||
					!areObjects
				) {
					if (escapeFields.indexOf(key) == -1)
						if (key.includes("date")) {
							if (val1 && val2)
								if (val1.substring(0, 10) != val2.substring(0, 10)) {
									console.log(key);
									return false;
								} else if (val1 && !val2) {
									console.log(key);
									return false;
								} else if (!val1 && val2) {
									console.log(key);
									return false;
								}
						} else {
							if (val1 != val2) {
								console.log(key);
								return false;
							}
						}
				}
			}
			return true;
		},
        /**
		 * Kiểm tra xem element có đang hiển thị không
		 * @param {Element} elem
		 * @returns {Boolean}
		 * CreatedBy: NTDUNG (28/09/2021)
		 */
		isVisible(elem) {
			if (!(elem instanceof Element))
				throw Error("DomUtil: elem is not an element.");
			const style = getComputedStyle(elem);
			if (style.display === "none") return false;
			if (style.visibility !== "visible") return false;
			if (style.opacity < 0.1) return false;
			if (
				elem.offsetWidth +
					elem.offsetHeight +
					elem.getBoundingClientRect().height +
					elem.getBoundingClientRect().width ===
				0
			) {
				return false;
			}
			const elemCenter = {
				x: elem.getBoundingClientRect().left + elem.offsetWidth / 2,
				y: elem.getBoundingClientRect().top + elem.offsetHeight / 2,
			};
			if (elemCenter.x < 0) return false;
			if (
				elemCenter.x >
				(document.documentElement.clientWidth || window.innerWidth)
			)
				return false;
			if (elemCenter.y < 0) return false;
			if (
				elemCenter.y >
				(document.documentElement.clientHeight || window.innerHeight)
			)
				return false;
			let pointContainer = document.elementFromPoint(
				elemCenter.x,
				elemCenter.y
			);
			do {
				if (pointContainer === elem) return true;
			} while ((pointContainer = pointContainer.parentNode));
			return false;
		},
    }
}