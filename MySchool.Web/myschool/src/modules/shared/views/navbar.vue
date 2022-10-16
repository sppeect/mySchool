<template>
    <div class="navbar">
       
        <span class="info mt-5">
            <p>MySchool</p>
            <p>Gestão de Escolas</p>
        </span>
        <div class="mt-5">
            <span v-for="(item, index) in itens" :key="index" class="menus" :class=" item.isActive? 'active' : '' ">
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
                    isActive: true
                },
                {
                    name: 'Turmas',
                    icon: 'people-fill',
                    isActive: false
                },
                {
                    name: 'Alunos',
                    icon: 'person-fill',
                    isActive: false
                },
                {
                    name: 'Notas',
                    icon: 'book',
                    isActive: false
                }
            ]
        }
    }

}
</script>
