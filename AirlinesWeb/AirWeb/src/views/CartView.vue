<template>
    <div class="container">
        <div class="bg-success m-2 w-100 rounded-3 p-2 text-center ">
            <h1 class="text-center">
             A jegyek végösszege: {{ossz}}
            </h1>
        </div>
    
<table class="table table-striped m-2 text-center">
    <thead class="bg-success bg-opacity">
        <tr>
        <th>Társaság:</th>
        <th>Kiinduló város:</th>
        <th>Cél város:</th>
        <th>Jegy(ek) ára (  {{ db }} darab )</th>
        <th></th>
    </tr>
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

</div>
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