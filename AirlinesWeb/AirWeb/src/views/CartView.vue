<template>
    <div class="container">
        <div class="bg-success m-2 w-100 rounded-3 p-2 text-center ">
            <h2 class="text-center">
             A jegyek végösszege {{ossz}}
            </h2>
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
        <tr v-for="item in cart" :key="item.Id">
            <td>{{item.Airline.Name}}</td>
            <td>{{item.From.Name}}</td>
            <td>{{item.Destination.Name}}</td>
            <td>{{item.Distance}} Ft</td> <!--Szorozni kell a darabszámmal-->
            <td><button class="btn btn-danger" @click="deleteItem(item.Id)" >Törlés</button></td>
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
            const ind = this.cart.findIndex(item => item.Id ===id);
            this.cart.splice(ind,1);
            localStorage.setItem('cart',JSON.stringify(this.cart));
        }
    },
    mounted(){
        this.getCart();
    }

}
</script>