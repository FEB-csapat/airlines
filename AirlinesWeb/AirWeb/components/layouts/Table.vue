<template>
<table class="table table-striped">
    <thead>
        <tr>
            <th>Légitársaság</th>
            <th>Kiinduló város</th>
            <th>Cél város</th>
            <th>Távolság (km)</th>
            <th>Repülési időtartam</th>
            <th>Kilométer ár</th>
        </tr>
    </thead>
    <tbody>
        <table-row v-for="flight in flights" :key="flight.id" :id="flight.id" :tarsasag="flight.Airline" :kiindulas="flight.From" :celvaros="flight.Destination" :tavolas="flight.Distance" :idotartam="flight.Flightduration" :kmar="flight.KmPrice" @add-to-cart="AddToCart" ></table-row>
    </tbody>
</table>
</template>
<script>
import TableRow from './TableRow.vue';
export default{
    data(){
        return{
            cart: []
        }
    },
    props:{
        flights: Array
    },
    components:{
        TableRow
    },
    methods:{
        AddToCart(id){
            const item = this.flights.find(item=>item.id === id );
            alert('Sikeres kosárba tétel!');
            this.cart.push(item);
            localStorage.setItem('cart',JSON.stringify(this.cart));
        }
    }
}
</script>