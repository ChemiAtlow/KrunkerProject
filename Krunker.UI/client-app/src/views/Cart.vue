<template>
    <div class="cart-page__wrapper" v-if="cartState.cart?.purchases.length">
        <div class="cart-page__wrapper-content">
            <item-view
                v-for="purchase in cartState.cart.purchases"
                :key="purchase.id"
                :id="purchase.id"
                type="purchase"
                :name="purchase.item.name"
                :img-name="purchase.item.uriImg"
                :amount="purchase.amount"
                :price="purchase.priceAtPurchase"
                :discount="purchase.discountRate"
                @action-executed="removePurchaseFromCart(purchase)"
            />
        </div>
        <cart-info />
    </div>
    <empty-view v-else />
</template>

<script lang="ts">
import { defineComponent, defineAsyncComponent } from "vue";
import { cartService } from "@/services";

const CartInfo = defineAsyncComponent({
    loader: () =>
        import(
            /* webpackChunkName: "group-cart" */ "@/components/CartInfo/index.vue"
        )
});

export default defineComponent({
    name: "CartView",
    components: { CartInfo },
    setup() {
        if (!cartService.state.cart) {
            cartService.getNewCart();
        }
        return {
            cartState: cartService.state,
            removePurchaseFromCart: cartService.removePurchaseFromCart
        };
    }
});
</script>

<style lang="scss" scoped>
.cart-page__wrapper {
    display: grid;
    grid-template-rows: 1fr $barHeight;
    height: 100%;
    &-content {
        display: flex;
        justify-content: center;
        align-items: flex-start;
        flex-wrap: wrap;
        overflow-y: auto;
    }
}
</style>
