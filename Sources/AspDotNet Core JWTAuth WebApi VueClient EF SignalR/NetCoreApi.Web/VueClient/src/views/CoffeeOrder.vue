<template>
    <div class="container">
        <header class="row">
            <div class="col-md-12 mt-5 mb-4">
                <h2>Please put your order ... <font-awesome-icon icon="coffee"/></h2>
            </div>
        </header>
        <form>
            <div class="row">
                <div class="form-group col-md-6">
                    <label htmlFor="product">Choose your product!</label>
                    <input type="text"
                           class="form-control"
                           v-model="product" />
                </div>
                <div class="form-group col-md-6">
                    <label htmlFor="size">Which size?</label>
                    <input type="text"
                           class="form-control"
                           v-model="size" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <button class="btn btn-primary" @click="order">
                        Order
                    </button>
                </div>
                <div class="col-md-6">
                    <span class="btn btn-success">{{status}}</span>
                </div>
            </div>
        </form>
    </div>
</template>

<script lang="ts">
import Vue from "vue";
import * as CoffeeService from "@/services/CoffeeService";
import {EventBus} from "@/global/EventBus";

export default Vue.extend({
    data() {
        return {
            product: 'Americano',
            size: 'Large',
            status: ''
        }
    },
    created(): void {
        EventBus.$on('order-status-changed', this.updateStatus);
    },
    methods: {
        order() {
            let id = 0;
            CoffeeService.order(this.product, this.size, this.$coffeeHubConnection)
            .then(response => id = response.data)
            .then(id => this.$coffeeHubConnection.invoke("GetUpdateForOrder", id));
        },
        updateStatus(status: string) {
            this.status = status;
        }
    }
});
</script>