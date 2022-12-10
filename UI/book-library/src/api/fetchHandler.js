const handle = (rawError) => {
    // Todo: Implement how to handle the raw error returned from the API
}

export const handlerError = (error) => {
    console.log("Error occured during the call to the API.");
    handle(error);
}