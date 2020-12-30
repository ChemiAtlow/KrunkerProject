<template>
    <div class="info__row">
        <div class="info__row-sum">
            Total price: {{ prettyNumber(state.cart?.totalPrice ?? 0) }}$
        </div>
        <app-button @click="purchaseCart">Proceed to payment</app-button>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { cartService } from "@/services";
import { prettyNumber } from "@/utils";

const component = defineComponent({
    name: "CartInfo",
    setup() {
        return {
            state: cartService.state,
            purchaseCart: cartService.purchaseCart,
            prettyNumber
        };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.info__row {
    padding: 0.5rem 1rem;
    background: $primary;
    color: $light;
    display: flex;
    align-items: center;
    justify-content: space-between;
    box-shadow: 0 -0.1rem 0.5rem $primaryLight;
    z-index: 2;
}
</style>