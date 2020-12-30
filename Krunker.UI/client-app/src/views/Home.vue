<template>
    <side-nav-view>
        <template #menu>
            <item-filter />
        </template>
        <template #content>
            <div class="shop" v-if="itemsState.items.length">
                <item-view
                    v-for="item in itemsState.items"
                    :key="item.id"
                    :id="item.id"
                    type="product"
                    :name="item.name"
                    :img-name="item.uriImg"
                    :amount="item.currentAmount"
                    :price="item.price"
                    :discount="item.discount"
                    @action-executed="setItemForCart(item)"
                />
            </div>
            <empty-view v-else />
        </template>
    </side-nav-view>
    <teleport to="body">
        <modal
            v-if="itemForCart"
            title="Validate purchase"
            :close="() => setItemForCart()"
        >
            <template #default>
                <purchase-validation
                    :item="itemForCart"
                    v-model.number="amount"
                    @validity-change="isValid = $event"
                />
            </template>
            <template #actions>
                <app-button light @click="() => setItemForCart()">
                    Cancel
                </app-button>
                <app-button
                    primary
                    :disabled="!isValid"
                    @click="attemptPurchase"
                >
                    Purchase
                </app-button>
            </template>
        </modal>
    </teleport>
</template>

<script lang="ts">
import { defineComponent, ref, defineAsyncComponent } from "vue";
import { itemsService, cartService } from "@/services";
import ItemFilter from "@/components/ItemFilter/index.vue";
import type { ShoppingItem } from '@/models';

const PurchaseValidation = defineAsyncComponent({
    loader: () =>
        import(
            /* webpackChunkName: "group-modal" */ "@/components/PurchaseValidation/index.vue"
        )
});

export default defineComponent({
    name: "HomeView",
    components: { ItemFilter, PurchaseValidation },
    setup() {
        itemsService.getAll();
        const amount = ref(1);
        const isValid = ref(false);
        const itemForCart = ref<ShoppingItem>();
        const setItemForCart = (item?: ShoppingItem) => {
            itemForCart.value = item;
            amount.value = 1;
        };
        const attemptPurchase = async () => {
            if (!itemForCart.value || !isValid.value) return;
            const { value: item } = itemForCart;
            const { value: purchaseAmount } = amount;
            setItemForCart();
            await cartService.addItemToCart(item, purchaseAmount);
        }
        return {
            amount,
            isValid,
            itemForCart,
            setItemForCart,
            attemptPurchase,
            itemsState: itemsService.state
        };
    }
});
</script>

<style lang="scss" scoped>
.shop {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-wrap: wrap;
    overflow-y: auto;
    height: 100%;
}
</style>
