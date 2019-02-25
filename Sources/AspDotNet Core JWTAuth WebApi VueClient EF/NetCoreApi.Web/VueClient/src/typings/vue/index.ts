// https://vuejs.org/v2/guide/typescript.html#Augmenting-Types-for-Use-with-Plugins
// https://stackoverflow.com/questions/50909703/augmenting-vue-js-in-typescript

import Vue from 'vue'

declare module 'vue/types/vue' {
  interface Vue {
    $toastr: any;
  }
}
