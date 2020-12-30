<template>
    <div class="filter__sections">
        <div class="filter__sections-filters">
            <div class="filter__sections-filters__in-stock">
                <app-filter
                    type="switch"
                    title="Hide items out of stock"
                    v-model="state.filters.stock"
                />
            </div>
            <div class="filter__sections-filters__discount">
                <app-filter
                    type="switch"
                    title="Show only discount items"
                    v-model="state.filters.discount"
                />
            </div>
            <div class="filter__sections-filters__type">
                <app-filter
                    type="selection"
                    title="Item types to show"
                    :options="['All', ...kinds]"
                    v-model="state.filters.type"
                />
            </div>
            <div class="filter__sections-filters__price-range">
                <app-filter
                    type="selection"
                    title="Price range"
                    :options="prices"
                    v-model="state.filters.price"
                />
            </div>
        </div>
        <div class="filter__sections-actions">
            <app-button primary @click="apply">Apply</app-button>
            <app-button light @click="reset">Reset</app-button>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { ItemKind, PriceFilter } from "@/models";
import { itemsService } from "@/services";
import AppFilter from "@/components/ItemFilter/Filter.vue";
import { getEnumKeys } from "@/utils";

const kinds = getEnumKeys(ItemKind);
const prices = getEnumKeys(PriceFilter);

const component = defineComponent({
    name: "ItemFilter",
    components: { AppFilter },
    setup() {
        const apply = () => itemsService.filterItems();
        const reset = () => itemsService.resetFilters();
        return {
            state: itemsService.state,
            kinds,
            prices,
            apply,
            reset
        };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.filter__sections {
    height: 100%;
    display: flex;
    justify-content: space-between;
    flex-direction: column;
    padding-bottom: 1rem;
}
</style>