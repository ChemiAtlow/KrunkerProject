<template>
    <div class="report__holder" v-if="cartState.reports.length">
        <report
            v-for="(report, index) in cartState.reports"
            :key="report.id"
            :report="report"
            :index="index + 1"
            @click="openModal(report)"
        />
    </div>
    <empty-view v-else />
    <teleport to="body">
        <modal
            v-if="reportForModal"
            title="Report"
            :close="() => openModal(undefined)"
        >
            <modal-details :report="reportForModal" />
        </modal>
    </teleport>
</template>

<script lang="ts">
import { defineComponent, defineAsyncComponent, ref } from "vue";
import { cartService } from "@/services";
import { ShoppingCart } from "@/models";

const Report = defineAsyncComponent({
    loader: () =>
        import(
            /* webpackChunkName: "group-admin" */ "@/components/PurchaseReports/Report.vue"
        )
});

const ModalDetails = defineAsyncComponent({
    loader: () =>
        import(
            /* webpackChunkName: "group-modal" */ "@/components/PurchaseReports/Details.vue"
        )
});

const component = defineComponent({
    name: "PurchaseReports",
    components: { Report, ModalDetails },
    setup() {
        cartService.getAllPurchases();
        const reportForModal = ref<ShoppingCart>();
        const openModal = (report?: ShoppingCart) =>
            (reportForModal.value = report);
        return { cartState: cartService.state, openModal, reportForModal };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.report__holder {
    height: 100%;
    overflow-y: auto;
    display: flex;
    flex-direction: column;
}
</style>