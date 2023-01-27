<template>
<table class="table table-striped m-2 text-center">
    <thead class="bg-success bg-opacity ">
        <tr>
            <th class="align-middle" >Légitársaság</th>
            <th class="align-middle" >Kiinduló város</th>
            <th class="align-middle" >Cél város</th>
            <th class="align-middle" >Távolság (km)</th>
            <th class="align-middle" >Repülési időtartam</th>
            <th class="align-middle" >Kilométer ár</th>
            <th class="align-middle" ></th>
            <th class="align-middle">Darab</th>
            <th class="align-middle" ></th>
            <th class="align-middle" ></th>
        </tr>
    </thead>
    <tbody>
        <table-row v-for="flight in flights" :key="flight.Id" :id="flight.Id" :tarsasag="flight.Airline.Name" :kiindulas="flight.From.Name" :celvaros="flight.Destination.Name" :tavolsag="flight.Distance" :idotartam="flight.FlightDuration" :kmar="flight.KmPrice" :db="flight.Db" @add-to-cart="AddToCart" @dec-quant="DecQuant" @add-quant="AddQuant"></table-row>
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
            const item = this.flights.find(item=>item.Id === id );
            alert('Sikeres kosárba tétel!');
            this.cart.push(item);
            localStorage.setItem('cart',JSON.stringify(this.cart));
        },
        AddQuant(id){
            this.flights.find(item=> item.Id ===id).Db++;
        },
        DecQuant(id){
            const szam = this.flights.find(item=> item.Id ===id).Db;

            if(szam!=0)
            {
                this.flights.find(item=> item.Id ===id).Db--;
            }
            
        }
    }
}
</script>
<style>

</style>