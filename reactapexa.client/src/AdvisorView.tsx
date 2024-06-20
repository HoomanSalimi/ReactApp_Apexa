
import { useEffect, useState } from 'react';

import * as React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import axios from 'axios';





const Appi = () => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [name, setName] = useState('');
    const [sin, setSin] = useState('');
    const [address, setAddress] = useState('');
    const [phone, setPhone] = useState('');
    const [editname, setEditname] = useState('');
    const [editsin, setEditsin] = useState('');
    const [editaddress, setEditaddress] = useState('');
    const [editphone, setEditphone] = useState('');
    const [editadvisorId, setEditadvisorId] = useState('');


    const handelEdit = (id) => {
        handleShow();
        axios.get("api/advisor/" + id)
            .then((res) => {
                setEditname(res.data.name);
                setEditaddress(res.data.address);
                setEditphone(res.data.phone);
                setEditsin(res.data.sin);
                setEditadvisorId(id);
            })
    }
    const handelDelete = (id) => {
        if (window.confirm("Are you sure ? ")) {
            axios.delete("api/advisor?id=" + id)
                .then((res) => {
                    alert("The advisor is deleted successfully");
                    getdata();
                })
                .catch((error) => { console.log(error) });

        }
    }
    const handelUpdate = () => {
        const url = `api/advisor/${editadvisorId}`;
        const data = { "name": editname, "sin": editsin, "address": editaddress, "phone": editphone, "advisorId": editadvisorId };
        if (editsin.toString().trim() !== '' && editname.toString().trim() !== '') {
            if (editphone.toString().trim().length <= 7 || editsin.toString().trim().length <= 8) {
                alert("Phone or Sin don't have enough characters");
            } else {

                axios.post(url, data)
                    .then((res) => {
                        if (res.status !== 204) {

                            handleClose();
                            getdata();
                            clearform();
                            alert("The advisor is Updated successfully");
                        } else {
                            alert("Data is already existed");
                        }
                    })
                    .catch((error) => { console.log(error) });
            }
        } else {
            alert("Data is empty");
        }
    }
    const handlerSave = () => {
        const url = "api/advisor";
        const data = { "name": name, "sin": sin, "address": address, "phone": phone, "advisorId": 0, "healthstatus": "" };

        if (sin.toString().trim() !== '' && name.toString().trim() !== '') {
            if (phone.toString().trim().length <= 7 || sin.toString().trim().length <= 8) {
                alert("Phone or Sin don't have enough characters");
            } else {

                axios.post(url, data)
                    .then((res) => {
                        if (res.status !== 204) {

                            getdata();
                            clearform();
                            alert("The advisor is added successfully");
                        } else {
                            alert("Data is already existed");
                        }
                    })
                    .catch((error) => { console.log(error) });
            }
        } else {
            alert("Data is empty");
        }
    }
    const [advisor, setAdvisor] = useState([])
    const [data, setData] = useState([])



    useEffect(() => {
        getdata()
    }, [])

    const getdata = () => {

        fetch('api/advisor')
            .then((response) => { return response.json() })
            .then(responsejson => { setData(responsejson) })
            .catch((error) => { console.log(error) });
    }
    const clearform = () => {
        setName('');
        setPhone('');
        setAddress('');
        setSin('');
        setEditname('');
        setEditsin('');
        setEditaddress('');
        setEditphone('');
        setEditadvisorId('');
    }

    return (<React.Fragment>

        <Container>
            <Row>
                <Col> <input type="text" className="form-control" placeholder="Enter Your Name" value={name} onChange={(e) => setName(e.target.value)} /> </Col>
            </Row>
            <Row>
                <Col> <input type="text" className="form-control" placeholder="Enter Your SIN" value={sin} onChange={(e) => setSin(e.target.value)} maxLength={9} minLength={8} /> </Col>
            </Row>
            <Row>
                <Col> <input type="text" className="form-control" placeholder="Enter Your address" value={address} onChange={(e) => setAddress(e.target.value)} /> </Col>
            </Row>
            <Row>
                <Col> <input type="text" className="form-control" placeholder="Enter Your phone" value={phone} onChange={(e) => setPhone(e.target.value)} maxLength={8} minLength={7} /> </Col>
                <Col> <button className="btn btn-primary" onClick={() => handlerSave()}>Add New</button> </Col>
            </Row>
        </Container>
        <br></br>

        <table className="container table table-dark table-striped-columns" >
            <thead>
                <tr>
                    <th>Name</th>
                    <th>SIN</th>
                    <th>Address</th>
                    <th>Phone</th>
                    <th>Health Status</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    data.map((item) => (
                        <tr key={item.advisorId}>
                            <td>{item.name}</td>
                            <td>{item.sin}</td>
                            <td>{item.address}</td>
                            <td>{item.phone}</td>
                            <td>{item.healthStatus}</td>
                            <td>
                                <button className="btn btn-primary" onClick={() => handelEdit(item.advisorId)}>Edit</button>&nbsp;&nbsp;
                                <button className="btn btn-danger" onClick={() => handelDelete(item.advisorId)}>Delete</button>
                            </td>
                        </tr>
                    ))

                }
            </tbody>
        </table>

        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Advisor Details</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Row>
                    <Col> <input type="text" className="form-control" placeholder="Enter Your Name" value={editname} onChange={(e) => setEditname(e.target.value)} /> </Col>
                </Row>
                <Row>
                    <Col> <input type="text" className="form-control" placeholder="Enter Your SIN" value={editsin} onChange={(e) => setEditsin(e.target.value)} maxLength={9} minLength={8} /> </Col>
                </Row>
                <Row>
                    <Col> <input type="text" className="form-control" placeholder="Enter Your address" value={editaddress} onChange={(e) => setEditaddress(e.target.value)} /> </Col>
                </Row>
                <Row>
                    <Col> <input type="text" className="form-control" placeholder="Enter Your phone" value={editphone} onChange={(e) => setEditphone(e.target.value)} maxLength={8} minLength={7} /> </Col>
                </Row>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Close
                </Button>
                <Button variant="primary" onClick={handelUpdate}>
                    Save Changes
                </Button>
            </Modal.Footer>
        </Modal>

    </React.Fragment>);



}

export default Appi;