<template>
    <div class="form">
        <h2>
            {{ mode === "create" ? "Create new item" : `Edit ${item.name}` }}.
        </h2>
        <form-field
            label="Item type"
            :type="kinds"
            :modelValue="ItemKind[item.kind]"
            @update:modelValue="setEnumValue(ItemKind, 'kind', $event)"
        />
        <form-field
            label="Name"
            type="text"
            v-model.trim="item.name"
            :validator="validators.isValidName"
            @validity-change="validationState.name = $event"
        />
        <form-field
            label="Discount"
            type="number"
            v-model.number="item.discount"
            :validator="validators.isNonNegativeNumber"
            @validity-change="validationState.discount = $event"
        />
        <form-field
            label="Price"
            type="number"
            v-model.number="item.price"
            :validator="validators.isGreaterThanZero"
            @validity-change="validationState.price = $event"
        />
        <form-field
            label="Amount in stock"
            type="number"
            v-model.number="item.currentAmount"
            :validator="validators.isNonNegativeNumber"
            @validity-change="validationState.amount = $event"
        />
        <form-field
            label="Image"
            type="file"
            v-model="item.image"
            :validator="validators.isValidFile"
            @validity-change="validationState.image = $event"
        />
        <template v-if="item.kind === ItemKind.BackItem">
            <form-field
                label="Is wings?"
                type="checkbox"
                v-model="item.isWings"
            />
        </template>
        <template
            v-if="
                item.kind === ItemKind.PrimaryWeapon ||
                    item.kind === ItemKind.SecondaryWeapon
            "
        >
            <form-field
                label="Creator"
                type="text"
                v-model.trim="item.creator"
                :validator="
                    val =>
                        validators.isNotEmptyString(val) &&
                        validators.isFirstCharLetter(val)
                "
                @validity-change="validationState.creator = $event"
            />
            <form-field
                label="Year"
                :validator="validators.is4DigitYear"
                type="number"
                v-model.number="item.year"
                @validity-change="validationState.year = $event"
            />
            <form-field
                label="Fire power"
                type="number"
                v-model.number="item.firePower"
                :validator="validators.isGreaterThanZero"
                @validity-change="validationState.firePower = $event"
            />
            <form-field
                label="Automatic"
                type="checkbox"
                v-model="item.automatic"
            />
            <template v-if="item.kind === ItemKind.PrimaryWeapon">
                <form-field
                    label="Amount of bullets"
                    type="number"
                    v-model.number="item.amountBalls"
                    :validator="validators.isGreaterThanZero"
                    @validity-change="validationState.bullets = $event"
                />
                <form-field
                    label="Shooting range"
                    type="number"
                    v-model.number="item.shootingRange"
                    :validator="validators.isGreaterThanZero"
                    @validity-change="validationState.range = $event"
                />
            </template>
            <template v-if="item.kind === ItemKind.SecondaryWeapon">
                <form-field
                    label="Knife length"
                    type="number"
                    v-model.number="item.knifeLength"
                    :validator="validators.isGreaterThanZero"
                    @validity-change="validationState.knifeLength = $event"
                />
                <form-field
                    label="Type of knife"
                    :type="knifes"
                    :modelValue="KnifeType[item.typeKnife ?? 0]"
                    @update:modelValue="
                        setEnumValue(KnifeType, 'typeKnife', $event)
                    "
                />
            </template>
        </template>
        <app-button :disabled="!isValid" @click="editOrCreateItem">
            Save
        </app-button>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref, computed, reactive } from "vue";
import { guid, Guid, ShoppingItemForm, ItemKind, KnifeType } from "@/models";
import { itemsService, messagesService } from "@/services";
import { getEnumKeys, validators } from "@/utils";

const component = defineComponent({
    name: "ItemForm",
    props: {
        itemId: {
            type: String as () => guid
        }
    },
    setup(props) {
        const validationState = reactive({
            name: false,
            discount: true,
            price: false,
            amount: true,
            image: false,
            creator: false,
            year: false,
            firePower: false,
            bullets: false,
            range: false,
            knifeLength: false
        });
        const mode = computed(() => (props.itemId ? "edit" : "create"));
        const kinds = getEnumKeys(ItemKind);
        const knifes = getEnumKeys(KnifeType);
        const item = ref<ShoppingItemForm>({
            kind: ItemKind.BackItem,
            name: "",
            discount: 0,
            price: 0,
            id: Guid.empty,
            currentAmount: 0,
            creator: ""
        });
        const isValid = computed(() => {
            const initial =
                validationState.name &&
                validationState.discount &&
                validationState.price &&
                validationState.amount;
            const fileByMode =
                mode.value === "edit" ||
                (Boolean(item.value.image) && validationState.image);
            const weaponInitial =
                validationState.creator &&
                validationState.year &&
                validationState.firePower;
            const primaryWeapon =
                item.value.kind !== ItemKind.PrimaryWeapon ||
                (weaponInitial &&
                    validationState.bullets &&
                    validationState.range);
            const secondaryWeapon =
                item.value.kind !== ItemKind.SecondaryWeapon ||
                (weaponInitial && validationState.knifeLength);
            return initial && fileByMode && primaryWeapon && secondaryWeapon;
        });
        const setEnumValue = <E extends { [key: string]: number | string }>(
            enumObject: E,
            key: keyof ShoppingItemForm,
            val: string
        ) => ((item.value[key] as number | string) = enumObject[val]);
        const editOrCreateItem = () => {
            if (!isValid.value) return;
            itemsService.editOrCreateItem(item.value);
        };
        if (props.itemId) {
            itemsService
                .getById(props.itemId)
                .then(i => (item.value = { ...i }))
                .catch(() =>
                    messagesService.showToast("Error getting requested file!")
                );
        }
        return {
            mode,
            item,
            kinds,
            knifes,
            isValid,
            ItemKind,
            KnifeType,
            validators,
            setEnumValue,
            validationState,
            editOrCreateItem
        };
    }
});

export default component;
</script>

<style lang="scss" scoped>
.form {
    height: 100%;
    overflow-y: auto;
    padding: 1rem 3rem;
    h2 {
        margin: 0;
    }
}
</style>