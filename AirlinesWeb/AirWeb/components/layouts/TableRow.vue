<template>
<tr>
    <td>{{tarsasag}}</td>
    <td>{{kiindulas}}</td>
    <td>{{celvaros}}</td>
    <td>{{tavolsag}}</td>
    <td>{{idotartam}}</td>
    <td>{{kmar}}</td>

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