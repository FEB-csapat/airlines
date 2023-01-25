<template>
<div class="container">
    <div class="bg-success m-2 w-100 rounded-3 p-2 text-center ">
        <h1>
            Menetrend kereső
        </h1>
    </div>
    <flight-table :flights="flights"></flight-table>
</div>
</template>

<script>
import FlightTable from '../../components/layouts/Table.vue';
export default{
    name: "IndexView",
    components:{
        FlightTable
    },
    data(){
        return{
            flights: [
                {
                    id:0,
                    Airline: "wizz",
                    From: "amerika",
                    Destination: "Berlin",
                    Distance: 50,
                    FlightDuration: 60,
                    KmPrice:2

                },
                {
                    id:1,
                    Airline: "luft",
                    From: "kongo",
                    Destination: "madrid",
                    Distance: 40,
                    FlightDuration: 60,
                    KmPrice:1
                }
            ]
        }
    },
    methods:{
        async dataFetch(){
            const resp = await fetch();
            this.flights = await resp.json();
        }
    },
    mounted(){
        this.dataFetch();
    }
    }
</script>

<style>
    body{
        background: url('../img/airport.jpg');
        background-repeat: no-repeat;
        background-size: cover;
    }
</style>