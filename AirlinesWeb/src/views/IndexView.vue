<template>
<div class="container">
    <div class="bg-success m-2 w-100 rounded-3 p-2 text-center ">
        <h2>
            Menetrend kereső
        </h2>
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
            flights: []
        }
    },
    methods:{
        async dataFetch(){

            const headers = {'Content-Type':'application/json'}
            const resp = await fetch('https://localhost:5000/flights',
            {
                method: 'GET',
                headers: headers
            });
            this.flights = await resp.json();
            this.flights.forEach(x=> x['Db']=0);
            console.log(this.flights);
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
        background-attachment: fixed;
    }
</style>