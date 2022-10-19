<template>
    <div class="navbar">

        <span class="info mt-5">
            <p>MySchool</p>
            <p>Gestão de Escolas</p>
        </span>
        <div class="mt-5">
            <span v-for="(item, index) in itens" :key="index" class="menus" :class=" item.isActive? 'active' : '' " @click="sendPage(item.page)">
                <b-icon :icon="item.icon" scale="1"></b-icon>
                <p>{{item.name}}</p>
            </span>
        </div>
    </div>
</template>

<script>
export default {
    name: 'navbar',
    data() {
        return {
            itens: [
                {
                    name: 'Dashboard',
                    icon: 'speedometer',
                    isActive: true,
                    page: 1
                },
                {
                    name: 'Escolas',
                    icon: 'house',
                    isActive: false,
                    page: 2
                },
                {
                    name: 'Turmas',
                    icon: 'people-fill',
                    isActive: false,
                    page: 3,
                },
                {
                    name: 'Alunos',
                    icon: 'person-fill',
                    isActive: false,
                    page: 4,
                },
                {
                    name: 'Notas',
                    icon: 'book',
                    isActive: false,
                    page: 5
                },

            ]
        }
    },
    methods:{
        sendPage(value){
            this.$emit('selectPage', value);
        }
    }

}
</script>
