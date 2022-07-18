export class Customer{    
    id?: string;
    email: string;
    phone: string;
    number?: number;
    typeInquiry: number;
    issueDescription: string;
    agreeTerms: boolean;

    constructor(){
        this.email = "";
        this.phone = "";
        this.typeInquiry = 0;
        this.issueDescription = "";
        this.agreeTerms = false;
    }
}
  