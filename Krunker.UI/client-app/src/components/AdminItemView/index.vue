<template>
    <admin-item-form v-if="route.params.id" :item-id="route.params.id" />
    <div class="admin-shop" v-else-if="itemsState.nonFilteredItems.length">
        <item-view
            v-for="item in itemsState.nonFilteredItems"
            :key="item.id"
            :id="item.id"
            type="admin"
            :name="item.name"
            :img-name="item.uriImg"
            :amount="item.currentAmount"
            :price="item.price"
            :discount="item.discount"
            @action-executed="goToEditPage(item.id)"
            @delete-item="deleteItem(item.id)"
        />
    </div>
    <empty-view v-else />
</template>

<script lang="ts">
import { defineComponent, defineAsyncComponent } from "vue";
import { useRouter, useRoute } from "vue-router";
import { itemsService } from "@/services";
import type { guid } from '@/models';

const AdminItemForm = defineAsyncComponent({
    loader: () => import(
        /* webpackChunkName: "group-admin" */ "@/components/ItemForm/index.vue"
    )
});
const component = defineComponent({
    name: "AdminItemView",
    components: { AdminItemForm },
    setup() {
        const router = useRouter();
        const route = useRoute();
        itemsService.getAll();
        const goToEditPage = (id: guid) => router.push({ name: "AdminItemView", params: { id } })
        return {
            itemsState: itemsService.state,
            deleteItem: itemsService.deleteItem,
            goToEditPage,
            route
        };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.admin-shop {
    height: 100%;
    overflow-y: auto;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-wrap: wrap;
}
</style>