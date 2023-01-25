<template>
<div class="container">
    <div class="bg-primary w-100">Menetrend kereső</div>
    <flight-table :flights="flights"></flight-table>
</div>
</template>

<script>
import { advancePositionWithClone } from '@vue/compiler-core';
import FlightTable from '../../components/layouts/Table.vue';
export default{
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
            ],
            cart:[]
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
