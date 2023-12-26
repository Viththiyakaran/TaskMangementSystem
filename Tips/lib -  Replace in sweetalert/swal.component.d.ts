import { AfterViewInit, EventEmitter, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import Swal, { SweetAlertOptions, SweetAlertResult, SweetAlertUpdatableParameters } from 'sweetalert2';
import * as events from './swal-events';
import { SweetAlert2LoaderService } from './sweetalert2-loader.service';
import * as i0 from "@angular/core";
/**
 * <swal> component. See the README.md for usage.
 *
 * It contains a bunch of @Inputs that have a perfect 1:1 mapping with SweetAlert2 options.
 * Their types are directly coming from SweetAlert2 types defintitions, meaning that ngx-sweetalert2 is tightly coupled
 * to SweetAlert2, but also is type-safe even if both libraries do not evolve in sync.
 *
 * (?) If you want to use an object that declares the SweetAlert2 options all at once rather than many @Inputs,
 *     take a look at [swalOptions], that lets you pass a full {@link SweetAlertOptions} object.
 *
 * (?) If you are reading the TypeScript source of this component, you may think that it's a lot of code.
 *     Be sure that a lot of this code is types and Angular boilerplate. Compiled and minified code is much smaller.
 *     If you are really concerned about performance and/or don't care about the API and its convenient integration
 *     with Angular (notably change detection and transclusion), you may totally use SweetAlert2 natively as well ;)
 *
 * /!\ Some SweetAlert options aren't @Inputs but @Outputs: `willOpen`, `didOpen`, `didRender`, `willClose`, `didClose`
 *     and `didDestroy`.
 *     However, `preConfirm`, `preDeny` and `inputValidator` are still @Inputs because they are not event handlers,
 *     there can't be multiple listeners on them, and we need the values they can/must return.
 */
export declare class SwalComponent implements OnInit, AfterViewInit, OnChanges, OnDestroy {
    private readonly sweetAlert2Loader;
    private readonly moduleLevelFireOnInit;
    private readonly moduleLevelDismissOnDestroy;
    title: SweetAlertOptions['title'];
    titleText: SweetAlertOptions['titleText'];
    text: SweetAlertOptions['text'];
    html: SweetAlertOptions['html'];
    footer: SweetAlertOptions['footer'];
    icon: SweetAlertOptions['icon'];
    iconColor: SweetAlertOptions['iconColor'];
    iconHtml: SweetAlertOptions['iconHtml'];
    backdrop: SweetAlertOptions['backdrop'];
    toast: SweetAlertOptions['toast'];
    target: SweetAlertOptions['target'];
    input: SweetAlertOptions['input'];
    width: SweetAlertOptions['width'];
    padding: SweetAlertOptions['padding'];
    background: SweetAlertOptions['background'];
    position: SweetAlertOptions['position'];
    grow: SweetAlertOptions['grow'];
    showClass: SweetAlertOptions['showClass'];
    hideClass: SweetAlertOptions['hideClass'];
    customClass: SweetAlertOptions['customClass'];
    timer: SweetAlertOptions['timer'];
    timerProgressBar: SweetAlertOptions['timerProgressBar'];
    heightAuto: SweetAlertOptions['heightAuto'];
    allowOutsideClick: SweetAlertOptions['allowOutsideClick'];
    allowEscapeKey: SweetAlertOptions['allowEscapeKey'];
    allowEnterKey: SweetAlertOptions['allowEnterKey'];
    stopKeydownPropagation: SweetAlertOptions['stopKeydownPropagation'];
    keydownListenerCapture: SweetAlertOptions['keydownListenerCapture'];
    showConfirmButton: SweetAlertOptions['showConfirmButton'];
    showDenyButton: SweetAlertOptions['showDenyButton'];
    showCancelButton: SweetAlertOptions['showCancelButton'];
    confirmButtonText: SweetAlertOptions['confirmButtonText'];
    denyButtonText: SweetAlertOptions['denyButtonText'];
    cancelButtonText: SweetAlertOptions['cancelButtonText'];
    confirmButtonColor: SweetAlertOptions['confirmButtonColor'];
    denyButtonColor: SweetAlertOptions['denyButtonColor'];
    cancelButtonColor: SweetAlertOptions['cancelButtonColor'];
    confirmButtonAriaLabel: SweetAlertOptions['confirmButtonAriaLabel'];
    denyButtonAriaLabel: SweetAlertOptions['denyButtonAriaLabel'];
    cancelButtonAriaLabel: SweetAlertOptions['cancelButtonAriaLabel'];
    buttonsStyling: SweetAlertOptions['buttonsStyling'];
    reverseButtons: SweetAlertOptions['reverseButtons'];
    focusConfirm: SweetAlertOptions['focusConfirm'];
    focusDeny: SweetAlertOptions['focusDeny'];
    focusCancel: SweetAlertOptions['focusCancel'];
    showCloseButton: SweetAlertOptions['showCloseButton'];
    closeButtonHtml: SweetAlertOptions['closeButtonHtml'];
    closeButtonAriaLabel: SweetAlertOptions['closeButtonAriaLabel'];
    loaderHtml: SweetAlertOptions['loaderHtml'];
    showLoaderOnConfirm: SweetAlertOptions['showLoaderOnConfirm'];
    preConfirm: SweetAlertOptions['preConfirm'];
    preDeny: SweetAlertOptions['preDeny'];
    imageUrl: SweetAlertOptions['imageUrl'];
    imageWidth: SweetAlertOptions['imageWidth'];
    imageHeight: SweetAlertOptions['imageHeight'];
    imageAlt: SweetAlertOptions['imageAlt'];
    inputLabel: SweetAlertOptions['inputLabel'];
    inputPlaceholder: SweetAlertOptions['inputPlaceholder'];
    inputValue: SweetAlertOptions['inputValue'];
    inputOptions: SweetAlertOptions['inputOptions'];
    inputAutoTrim: SweetAlertOptions['inputAutoTrim'];
    inputAttributes: SweetAlertOptions['inputAttributes'];
    inputValidator: SweetAlertOptions['inputValidator'];
    returnInputValueOnDeny: SweetAlertOptions['returnInputValueOnDeny'];
    validationMessage: SweetAlertOptions['validationMessage'];
    progressSteps: SweetAlertOptions['progressSteps'];
    currentProgressStep: SweetAlertOptions['currentProgressStep'];
    progressStepsDistance: SweetAlertOptions['progressStepsDistance'];
    scrollbarPadding: SweetAlertOptions['scrollbarPadding'];
    /**
     * An object of SweetAlert2 native options, useful if:
     *  - you don't want to use the @Inputs for practical/philosophical reasons ;
     *  - there are missing @Inputs because ngx-sweetalert2 isn't up-to-date with SweetAlert2's latest changes.
     *
     * /!\ Please note that setting this property does NOT erase what has been set before unless you specify the
     *     previous properties you want to erase again.
     *     Ie. setting { title: 'Title' } and then { text: 'Text' } will give { title: 'Title', text: 'Text' }.
     *
     * /!\ Be aware that the options defined in this object will override the @Inputs of the same name.
     */
    set swalOptions(options: SweetAlertOptions);
    /**
     * Computes the options object that will get passed to SweetAlert2.
     * Only the properties that have been set at least once on this component will be returned.
     * Mostly for internal usage.
     */
    get swalOptions(): SweetAlertOptions;
    /**
     * Whether to fire the modal as soon as the <swal> component is created and initialized in the view.
     * When left undefined (default), the value will be inherited from the module configuration, which is `false`.
     *
     * Example:
     *     <swal *ngIf="error" [title]="error.title" [text]="error.text" icon="error" [swalFireOnInit]="true"></swal>
     */
    swalFireOnInit?: boolean;
    /**
     * Whether to dismiss the modal when the <swal> component is destroyed by Angular (for any reason) or not.
     * When left undefined (default), the value will be inherited from the module configuration, which is `true`.
     */
    swalDismissOnDestroy?: boolean;
    set swalVisible(visible: boolean);
    get swalVisible(): boolean;
    /**
     * Modal lifecycle hook. Synchronously runs before the modal is shown on screen.
     */
    readonly willOpen: EventEmitter<events.WillOpenEvent>;
    /**
     * Modal lifecycle hook. Synchronously runs before the modal is shown on screen.
     */
    readonly didOpen: EventEmitter<events.DidOpenEvent>;
    /**
     * Modal lifecycle hook. Synchronously runs after the popup DOM has been updated (ie. just before the modal is
     * repainted on the screen).
     * Typically, this will happen after `Swal.fire()` or `Swal.update()`.
     * If you want to perform changes in the popup's DOM, that survive `Swal.update()`, prefer {@link didRender} over
     * {@link willOpen}.
     */
    readonly didRender: EventEmitter<events.DidRenderEvent>;
    /**
     * Modal lifecycle hook. Synchronously runs when the popup closes by user interaction (and not due to another popup
     * being fired).
     */
    readonly willClose: EventEmitter<events.WillCloseEvent>;
    /**
     * Modal lifecycle hook. Asynchronously runs after the popup has been disposed by user interaction (and not due to
     * another popup being fired).
     */
    readonly didClose: EventEmitter<void>;
    /**
     * Modal lifecycle hook. Synchronously runs after popup has been destroyed either by user interaction or by another
     * popup.
     * If you have cleanup operations that you need to reliably execute each time a modal is closed, prefer
     * {@link didDestroy} over {@link didClose}.
     */
    readonly didDestroy: EventEmitter<void>;
    /**
     * Emits when the user clicks "Confirm".
     * The event value ($event) can be either:
     *  - by default, just `true`,
     *  - when using {@link input}, the input value,
     *  - when using {@link preConfirm}, the return value of this function.
     *
     * Example:
     *     <swal (confirm)="handleConfirm($event)"></swal>
     *
     *     public handleConfirm(email: string): void {
     *         // ... save user email
     *     }
     */
    readonly confirm: EventEmitter<any>;
    /**
     * Emits when the user clicks "Deny".
     * This event bears no value.
     * Use `(deny)` (along with {@link showDenyButton}) when you want a modal with three buttons (confirm, deny and
     * cancel), and/or when you want to handle clear refusal in a separate way than simple dismissal.
     *
     * Example:
     *     <swal (deny)="handleDeny()"></swal>
     *
     *     public handleDeny(): void {
     *     }
     */
    readonly deny: EventEmitter<void>;
    /**
     * Emits when the user clicks "Cancel", or dismisses the modal by any other allowed way.
     * The event value ($event) is a string that explains how the modal was dismissed. It is `undefined` when
     * the modal was programmatically closed (through {@link close} for example).
     *
     * Example:
     *     <swal (dismiss)="handleDismiss($event)"></swal>
     *
     *     public handleDismiss(reason: DismissReason | undefined): void {
     *         // reason can be 'cancel', 'overlay', 'close', 'timer' or undefined.
     *         // ... do something
     *     }
     */
    readonly dismiss: EventEmitter<Swal.DismissReason | undefined>;
    /**
     * This Set retains the properties that have been changed from @Inputs, so we can know precisely
     * what options we have to send to {@link Swal.fire}.
     */
    private readonly touchedProps;
    /**
     * A function of signature `(propName: string): void` that adds a given property name to the list of
     * touched properties, ie. {@link touchedProps}.
     */
    private readonly markTouched;
    /**
     * Is the SweetAlert2 modal represented by this component currently opened?
     */
    private isCurrentlyShown;
    constructor(sweetAlert2Loader: SweetAlert2LoaderService, moduleLevelFireOnInit: boolean, moduleLevelDismissOnDestroy: boolean);
    /**
     * Angular lifecycle hook.
     * Asks the SweetAlert2 loader service to preload the SweetAlert2 library, so it begins to be loaded only if there
     * is a <swal> component somewhere, and is probably fully loaded when the modal has to be displayed,
     * causing no delay.
     */
    ngOnInit(): void;
    /**
     * Angular lifecycle hook.
     * Fires the modal, if the component or module is configured to do so.
     */
    ngAfterViewInit(): void;
    /**
     * Angular lifecycle hook.
     * Updates the SweetAlert options, and if the modal is opened, asks SweetAlert to render it again.
     */
    ngOnChanges(changes: SimpleChanges): void;
    /**
     * Angular lifecycle hook.
     * Closes the SweetAlert when the component is destroyed.
     */
    ngOnDestroy(): void;
    /**
     * Shows the SweetAlert.
     *
     * Returns the SweetAlert2 promise for convenience and use in code behind templates.
     * Otherwise, (confirm)="myHandler($event)" and (dismiss)="myHandler($event)" can be used in templates.
     */
    fire(): Promise<SweetAlertResult>;
    /**
     * Closes the modal, if opened.
     *
     * @param result The value that the modal will resolve with, triggering either (confirm), (deny) or (dismiss).
     *               If the argument is not passed, it is (dismiss) that will emit an `undefined` reason.
     *               {@see Swal.close}.
     */
    close(result?: SweetAlertResult): Promise<void>;
    /**
     * Updates SweetAlert2 options while the modal is opened, causing the modal to re-render.
     * If the modal is not opened, the component options will simply be updated and that's it.
     *
     * /!\ Please note that not all SweetAlert2 options are updatable while the modal is opened.
     *
     * @param options
     */
    update(options?: Pick<SweetAlertOptions, SweetAlertUpdatableParameters>): Promise<void>;
    static ɵfac: i0.ɵɵFactoryDeclaration<SwalComponent, never>;
    static ɵcmp: i0.ɵɵComponentDeclaration<SwalComponent, "swal", never, {
      "title": string;
      "titleText": string;
      "text": string;
      "html": string;
      "footer": string;
      "icon": string;
      "iconColor": string;
      "iconHtml": string;
      "backdrop": string;
      "toast": string;
      "target": string;
      "input": string;
      "width": string;
      "padding": string;
      "background": string;
      "position": string;
      "grow": string;
      "showClass": string;
      "hideClass": string;
      "customClass": string;
      "timer": string;
      "timerProgressBar": string;
      "heightAuto": string;
      "allowOutsideClick": string;
      "allowEscapeKey": string;
      "allowEnterKey": string;
      "stopKeydownPropagation": string;
      "keydownListenerCapture": string;
      "showConfirmButton": string;
      "showDenyButton": string;
      "showCancelButton": string;
      "confirmButtonText": string;
      "denyButtonText": string;
      "cancelButtonText": string;
      "confirmButtonColor": string;
      "denyButtonColor": string;
      "cancelButtonColor": string;
      "confirmButtonAriaLabel": string;
      "denyButtonAriaLabel": string;
      "cancelButtonAriaLabel": string;
      "buttonsStyling": string;
      "reverseButtons": string;
      "focusConfirm": string;
      "focusDeny": string;
      "focusCancel": string;
      "showCloseButton": string;
      "closeButtonHtml": string;
      "closeButtonAriaLabel": string;
      "loaderHtml": string;
      "showLoaderOnConfirm": string;
      "preConfirm": string;
      "preDeny": string;
      "imageUrl": string;
      "imageWidth": string;
      "imageHeight": string;
      "imageAlt": string;
      "inputLabel": string;
      "inputPlaceholder": string;
      "inputValue": string;
      "inputOptions": string;
      "inputAutoTrim": string;
      "inputAttributes": string;
      "inputValidator": string;
      "returnInputValueOnDeny": string;
      "validationMessage": string;
      "progressSteps": string;
      "currentProgressStep": string;
      "progressStepsDistance": string;
      "scrollbarPadding": string;
      "swalOptions": string;
      "swalFireOnInit": string;
      "swalDismissOnDestroy": string;
      "swalVisible": string;
    }, {
      "willOpen": "willOpen";
      "didOpen": "didOpen";
      "didRender": "didRender";
      "willClose": "willClose";
      "didClose": "didClose";
      "didDestroy": "didDestroy";
      "confirm": "confirm";
      "deny": "deny";
      "dismiss": "dismiss";
    }, never, never, false, never>;

}