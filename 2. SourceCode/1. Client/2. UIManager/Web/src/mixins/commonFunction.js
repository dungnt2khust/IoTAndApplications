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
        }
    }
}