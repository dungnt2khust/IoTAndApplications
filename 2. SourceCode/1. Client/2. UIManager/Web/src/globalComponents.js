import Vue from 'vue'

import BaseContentArea from '@/layouts/basecontentarea/BaseContentArea.vue'
Vue.component('BaseContentArea', BaseContentArea);

import FullScreen from '@/layouts/FullScreen.vue'
Vue.component('FullScreen', FullScreen);

import Logo from '@/layouts/logo/Logo.vue'
Vue.component('EdLogo', Logo);

import GridProduct from '@/layouts/gridproduct/GridProduct.vue'
Vue.component('EdGridProduct', GridProduct);

import ListProduct from '@/layouts/listproduct/ListProduct.vue'
Vue.component('EdListProduct', ListProduct);

const BaseContentFrame = () => import('@/layouts/basecontentframe/BaseContentFrame.vue');
Vue.component('BaseContentFrame', BaseContentFrame);

const Col = () => import('@/layouts/col/Col.vue');
Vue.component('EdCol', Col);

const Row = () => import('@/layouts/row/Row.vue');
Vue.component('EdRow', Row);

const Popup = () => import('@/components/popup/Popup.vue');
Vue.component('EdPopup', Popup);

const Label = () => import('@/components/label/Label.vue');
Vue.component('EdLabel', Label);

const Input = () => import('@/components/input/Input.vue');
Vue.component('EdInput', Input);

const Textarea = () => import('@/components/textarea/Textarea.vue');
Vue.component('EdTextarea', Textarea);

const Button = () => import('@/components/button/Button.vue');
Vue.component('EdButton', Button);

const Icon = () => import('@/components/icon/Icon.vue');
Vue.component('EdIcon', Icon);

const Blur = () => import('@/components/basecomponents/blur/Blur.vue');
Vue.component('EdBlur', Blur);

const INumber = () => import('@/components/number/Number.vue');
Vue.component('EdNumber', INumber);

const SelectBox = () => import('@/components/selectbox/selectbox.vue')
Vue.component('EdSelectBox', SelectBox);

const ListGrid = () => import('@/components/listgrid/ListGrid.vue');
Vue.component('EdListGrid', ListGrid);

const CheckBox = () => import('@/components/checkbox/CheckBox.vue');
Vue.component('EdCheckBox', CheckBox);
