<template>
    <div class="fading">
        <div class="forms">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <label for="name">Nome</label>
                        <input type="text" id="name" name="name" v-model="name" class="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <label for="street">Rua</label>
                        <input type="text" id="street" name="street" v-model="street" class="form-control" />
                    </div>
                    <div class="col-4">
                        <label for="number">Número</label>
                        <input type="text" id="number" name="number" v-model="number" class="form-control" />
                    </div>
                    <div class="col-4">
                        <label for="neighborhood">Bairro</label>
                        <input type="text" id="neighborhood" name="neighborhood" v-model="neighborhood" class="form-control" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-4">
                        <label for="city">Cidade</label>
                        <input type="text" id="city" name="city" v-model="city" class="form-control" />

                    </div>
                    <div class="col-4">
                        <label for="state">Estado</label>
                        <input type="text" id="state" name="state" v-model="state" class="form-control" />

                    </div>
                    <div class="col-4">
                        <label for="country">País</label>
                        <input type="text" id="country" name="country" v-model="country" class="form-control" />

                    </div>
                </div>

                <div class="row">
                    <div class="col-4">

                        <label for="zipcode">CEP</label>
                        <input type="text" id="zipcode" name="zipcode" v-model="zipcode" class="form-control" />
                    </div>
                    <div class="col-4">
                        <label for="phone">Telefone</label>
                        <input type="phone" id="phone" name="phone" v-model="phone" class="form-control" />
                    </div>
                    <div class="col-4">
                        <label for="email">Email</label>
                        <input type="email" id="email" name="email" v-model="email" class="form-control" />
                    </div>
                </div>
                <label for="document">Documento</label>
                <input type="text" id="document" name="document" v-model="document" class="form-control" />
            </div>
            <button @click="createSchool">Cadastrar</button>
            <button @click="closeModal">Fechar</button>

        </div>
    </div>
</template>

<script>
import {mapActions} from 'vuex';
export default {
    name: "modal",
    data() {
        return {
            name: "",
            street: "",
            number: null,
            neighborhood: "",
            city: "",
            state: "",
            country: "",
            zipcode: "",
            phone: null,
            email: "",
            document: null,
            documentType: 2
        }
    },
    computed:{
        getDocumentType(){
            let document = this.document;
            if(document.length <= 11)
            {
                return this.documentType = 1;
            }
            else
            {
                return this.documentType = 2;
            }
            
        }
    },
    methods:{
        ...mapActions({
            post:"home/createSchool"
        }),

        createSchool(){
            let school = {
                Name:this.name,
                Street:this.street,
                Number:this.number,
                Neighborhood: this.neighborhood,
                City: this.city,
                State: this.state,
                Country: this.country,
                ZipCode: this.zipcode,
                Phone:this.phone,
                Email: this.email,
                Document: this.document,
                DocumentType: this.getDocumentType
            }
            this.post(school).then((resp) => {
                if (resp.data) {
                    console.log("Criado com sucesso!");
                    this.$emit("closeModal");
                }
            });
        },
        closeModal(){
            this.$emit("closeModal");
        }
    }

}
</script>
