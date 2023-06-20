export interface Person {
    name: string;
    id: number;
    employeeLocation: (Location: string) => void
}


const person1:Person = {
    name: 'Kyle',
    id: 2,
    employeeLocation: (location:any ) => console.log(location)

}

const person2:Person = {
    name: 'Siba',
    id: 3,
    employeeLocation: (location:any ) => console.log(location)

}

person1.employeeLocation('Joburg');

export const persons = [person1, person2]