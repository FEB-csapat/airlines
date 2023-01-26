<template>
<tr>
    <td class="align-middle">{{tarsasag}}</td>
    <td class="align-middle">{{kiindulas}}</td>
    <td class="align-middle">{{celvaros}}</td>
    <td class="align-middle">{{tavolsag}} km</td>
    <td class="align-middle">{{idotartam}} perc</td>
    <td class="align-middle">{{kmar}} Ft</td>

    <td><button class="btn btn-success" @click="$emit('AddToCart',id)">Kosárba teszem</button></td>
</tr>
</template>
<script>
export default{
    props:{
        id: Number,
        tarsasag: String,
        kiindulas: String,
        celvaros: String,
        tavolsag: Number,
        idotartam: Number,
        kmar: Number
    },
    emits: ['AddToCart']
}
</script>