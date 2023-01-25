<template>
<h1 class="text-center">A jegyek végösszege: {{ossz}}</h1>
<table class="table table-striped">
    <thead>
        <th>Társaság:</th>
        <th>Kiinduló város:</th>
        <th>Cél város:</th>
        <th>Jegy(ek) ára (  {{ db }} darab )</th>
    </thead>
    <tbody>
        <tr v-for="item in cart" :key="item.id">
            <td>{{item.Airline}}</td>
            <td>{{item.From}}</td>
            <td>{{item.Destination}}</td>
            <td>{{item.Distance}} Ft</td> <!--Szorozni kell a darabszámmal-->
            <td><button class="btn btn-danger" @click="deleteItem(item.id)" >Törlés</button></td>
        </tr>
    </tbody>
</table>
</template>
<script>

export default{
    name: "Cartview.vue",
    data(){
        return{
             cart:[]
        }
    },
    methods:{
        getCart(){
            this.cart = JSON.parse(localStorage.getItem('cart')) ?? []
        },
        deleteItem(id){
            const ind = this.cart.findIndex(item => item.id ===id);
            this.cart.splice(ind,1);
            localStorage.setItem('cart',JSON.stringify(this.cart));
        }
    },
    mounted(){
        this.getCart();
    }

}
</script>