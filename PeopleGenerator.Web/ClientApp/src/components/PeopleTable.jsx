export default function PeopleTable({people}) {
    return <>
    <table className="table table-bordered table-hover mt-5">
        <thead>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Age</th>
                <th>Address</th>
                <th>Email</th>
            </tr>
        </thead>
        <tbody>
            {people.map(({id, firstName, lastName, age, address, email}) => 
            <tr key={id}>
                <td>{firstName}</td>
                <td>{lastName}</td>
                <td>{age}</td>
                <td>{address}</td>
                <td>{email}</td>
            </tr>)}
        </tbody>
    </table>
    </>
}