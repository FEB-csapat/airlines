<template>
<div class="container">
    <div class="bg-primary w-100">Menetrend kereső</div>
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
              /*  {
                    id:0,
                    Airline: "wizz",
                    From: "amerika",
                    Destination: "Berlin",
                    Distance: 50,
                    FlightDuration: 60,
                    KmPrice:2

                },
                {
                    Id:1,
                    Airline: "luft",
                    From: "kongo",
                    Destination: "madrid",
                    Distance: 40,
                    FlightDuration: 60,
                    KmPrice:1
                }

                */
            ]
        }
    },
    methods:{
        async dataFetch(){
            const headers = {'Content-Type':'application/json',
                    'Access-Control-Allow-Origin':'*',
                    'Access-Control-Allow-Methods':'POST,PATCH,OPTIONS'}

            const resp = await fetch('https://localhost:5000/flights/2',
            {
                method: 'GET',
                headers: headers
            });
            this.flights = await resp.json();
        }
    },
    mounted(){
        this.dataFetch();
    }
    }
</script>
